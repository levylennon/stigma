namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Spell;

public sealed class SpellForgottenMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5834;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<short> SpellsId { get; set; }

    public required short BoostPoint { get; set; }

    public SpellForgottenMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var spellsIdBefore = writer.Position;
        var spellsIdCount = 0;
        writer.WriteInt16(0);
        foreach (var item in SpellsId)
        {
            writer.WriteInt16(item);
            spellsIdCount++;
        }

        var spellsIdAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, spellsIdBefore);
        writer.WriteInt16((short)spellsIdCount);
        writer.Seek(SeekOrigin.Begin, spellsIdAfter);
        writer.WriteInt16(BoostPoint);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var spellsIdCount = reader.ReadInt16();
        var spellsId = new short[spellsIdCount];
        for (var i = 0; i < spellsIdCount; i++) spellsId[i] = reader.ReadInt16();
        SpellsId = spellsId;
        BoostPoint = reader.ReadInt16();
    }
}