namespace Stigma.Protocol.Messages.Game.Actions;

public sealed class AbstractGameActionWithAckMessage : AbstractGameActionMessage
{
    public new const uint ProtocolMessageId = 1001;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short WaitAckId { get; set; }

    public AbstractGameActionWithAckMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(WaitAckId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        WaitAckId = reader.ReadInt16();
    }
}