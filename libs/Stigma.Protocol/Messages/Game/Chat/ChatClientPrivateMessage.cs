namespace Stigma.Protocol.Messages.Game.Chat;

public class ChatClientPrivateMessage : ChatAbstractClientMessage
{
    public new const uint ProtocolMessageId = 851;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string Receiver { get; set; }

    public ChatClientPrivateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUtf(Receiver);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Receiver = reader.ReadUtf();
    }
}