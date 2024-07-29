namespace Stigma.Protocol.Messages.Game.Social;

public class ContactLookRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5932;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required byte RequestId { get; set; }

    public required sbyte ContactType { get; set; }

    public ContactLookRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUInt8(RequestId);
        writer.WriteInt8(ContactType);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        RequestId = reader.ReadUInt8();
        ContactType = reader.ReadInt8();
    }
}