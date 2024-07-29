namespace Stigma.Protocol.Messages.Game.Chat;

public class ChatServerCopyMessage : ChatAbstractServerMessage
{
    public new const uint ProtocolMessageId = 882;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int ReceiverId { get; set; }

    public required string ReceiverName { get; set; }

    public ChatServerCopyMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(ReceiverId);
        writer.WriteUtf(ReceiverName);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        ReceiverId = reader.ReadInt32();
        ReceiverName = reader.ReadUtf();
    }
}