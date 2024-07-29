namespace Stigma.Protocol.Messages.Queues;

public sealed class QueueStatusMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6100;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required ushort Position { get; set; }

    public required ushort Total { get; set; }

    public QueueStatusMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUInt16(Position);
        writer.WriteUInt16(Total);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Position = reader.ReadUInt16();
        Total = reader.ReadUInt16();
    }
}