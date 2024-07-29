namespace Stigma.Protocol.Messages.Connection;

public class IdentificationFailedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 20;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Reason { get; set; }

    public IdentificationFailedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(Reason);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Reason = reader.ReadInt8();
    }
}