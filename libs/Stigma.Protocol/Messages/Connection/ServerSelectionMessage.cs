namespace Stigma.Protocol.Messages.Connection;

public sealed class ServerSelectionMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 40;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short ServerId { get; set; }

    public ServerSelectionMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(ServerId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ServerId = reader.ReadInt16();
    }
}