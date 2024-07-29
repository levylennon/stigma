namespace Stigma.Protocol.Messages.Connection;

public sealed class IdentificationMessageWithServerIdMessage : IdentificationMessage
{
    public new const uint ProtocolMessageId = 6104;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short ServerId { get; set; }

    public IdentificationMessageWithServerIdMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(ServerId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        ServerId = reader.ReadInt16();
    }
}