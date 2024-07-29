using Stigma.Protocol.Types.Game.Action.Fight;

namespace Stigma.Protocol.Messages.Game.Context.Fight;

public class GameFightSpectateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6069;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<FightDispellableEffectExtendedInformations> Effects { get; set; }

    public GameFightSpectateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var effectsBefore = writer.Position;
        var effectsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Effects)
        {
            writer.WriteUInt16(item.ProtocolId);
            item.Serialize(writer);
            effectsCount++;
        }

        var effectsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, effectsBefore);
        writer.WriteInt16((short)effectsCount);
        writer.Seek(SeekOrigin.Begin, effectsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var effectsCount = reader.ReadInt16();
        var effects = new FightDispellableEffectExtendedInformations[effectsCount];
        for (var i = 0; i < effectsCount; i++)
        {
            var entry = DofusTypeFactory.CreateInstance<FightDispellableEffectExtendedInformations>(reader.ReadUInt16());
            entry.Deserialize(reader);
            effects[i] = entry;
        }

        Effects = effects;
    }
}