namespace Stigma.Protocol.Messages.Game.Actions.Fight;

public class GameActionFightDispellMessage : AbstractGameActionMessage
{
    public new const uint ProtocolMessageId = 5533;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int TargetId { get; set; }

    public GameActionFightDispellMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(TargetId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        TargetId = reader.ReadInt32();
    }
}