namespace Stigma.Protocol.Messages.Connection;

public sealed class SelectedServerRefusedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 41;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short ServerId { get; set; }

    public required sbyte Error { get; set; }

    public required sbyte ServerStatus { get; set; }

    public SelectedServerRefusedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(ServerId);
        writer.WriteInt8(Error);
        writer.WriteInt8(ServerStatus);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ServerId = reader.ReadInt16();
        Error = reader.ReadInt8();
        ServerStatus = reader.ReadInt8();
    }
}