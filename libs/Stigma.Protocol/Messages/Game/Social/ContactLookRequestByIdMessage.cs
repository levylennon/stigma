namespace Stigma.Protocol.Messages.Game.Social;

public sealed class ContactLookRequestByIdMessage : ContactLookRequestMessage
{
    public new const uint ProtocolMessageId = 5935;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int PlayerId { get; set; }

    public ContactLookRequestByIdMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(PlayerId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        PlayerId = reader.ReadInt32();
    }
}