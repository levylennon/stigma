using Stigma.Protocol.Types.Game.Look;

namespace Stigma.Protocol.Messages.Game.Actions.Fight;

public sealed class GameActionFightChangeLookMessage : AbstractGameActionMessage
{
    public new const uint ProtocolMessageId = 5532;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int TargetId { get; set; }

    public required EntityLook EntityLookValue { get; set; }

    public GameActionFightChangeLookMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(TargetId);
        EntityLookValue.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        TargetId = reader.ReadInt32();
        EntityLookValue = new EntityLook();
        EntityLookValue.Deserialize(reader);
    }
}