namespace Stigma.Protocol.Messages.Game.Chat;

public class ChatAbstractClientMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 850;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string Content { get; set; }

    public ChatAbstractClientMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUtf(Content);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Content = reader.ReadUtf();
    }
}