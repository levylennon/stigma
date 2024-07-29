namespace Stigma.Protocol.Messages.Game.Chat;

public class ChatServerMessage : ChatAbstractServerMessage
{
    public new const uint ProtocolMessageId = 881;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int SenderId { get; set; }

    public required string SenderName { get; set; }

    public ChatServerMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(SenderId);
        writer.WriteUtf(SenderName);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        SenderId = reader.ReadInt32();
        SenderName = reader.ReadUtf();
    }
}