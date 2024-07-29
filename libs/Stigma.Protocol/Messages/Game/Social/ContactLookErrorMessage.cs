namespace Stigma.Protocol.Messages.Game.Social;

public sealed class ContactLookErrorMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6045;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int RequestId { get; set; }

    public ContactLookErrorMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(RequestId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        RequestId = reader.ReadInt32();
    }
}