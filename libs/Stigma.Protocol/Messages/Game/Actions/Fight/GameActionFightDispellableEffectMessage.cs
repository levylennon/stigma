using Stigma.Protocol.Types.Game.Actions.Fight;

namespace Stigma.Protocol.Messages.Game.Actions.Fight;

public sealed class GameActionFightDispellableEffectMessage : AbstractGameActionMessage
{
    public new const uint ProtocolMessageId = 6070;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required AbstractFightDispellableEffect Effect { get; set; }

    public GameActionFightDispellableEffectMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUInt16(Effect.ProtocolId);
        Effect.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Effect = DofusTypeFactory.CreateInstance<AbstractFightDispellableEffect>(reader.ReadUInt16());
        Effect.Deserialize(reader);
    }
}