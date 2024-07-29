using Stigma.Protocol.Types.Game.Context.Fight;

namespace Stigma.Protocol.Messages.Game.Context.Fight;

public sealed class GameFightResumeMessage : GameFightSpectateMessage
{
    public new const uint ProtocolMessageId = 6067;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<GameFightSpellCooldown> SpellCooldowns { get; set; }

    public required sbyte SummonCount { get; set; }

    public GameFightResumeMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        var spellCooldownsBefore = writer.Position;
        var spellCooldownsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in SpellCooldowns)
        {
            item.Serialize(writer);
            spellCooldownsCount++;
        }

        var spellCooldownsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, spellCooldownsBefore);
        writer.WriteInt16((short)spellCooldownsCount);
        writer.Seek(SeekOrigin.Begin, spellCooldownsAfter);
        writer.WriteInt8(SummonCount);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        var spellCooldownsCount = reader.ReadInt16();
        var spellCooldowns = new GameFightSpellCooldown[spellCooldownsCount];
        for (var i = 0; i < spellCooldownsCount; i++)
        {
            var entry = new GameFightSpellCooldown();
            entry.Deserialize(reader);
            spellCooldowns[i] = entry;
        }

        SpellCooldowns = spellCooldowns;
        SummonCount = reader.ReadInt8();
    }
}