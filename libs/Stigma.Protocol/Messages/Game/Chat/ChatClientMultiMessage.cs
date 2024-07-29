namespace Stigma.Protocol.Messages.Game.Chat;

public class ChatClientMultiMessage : ChatAbstractClientMessage
{
    public new const uint ProtocolMessageId = 861;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Channel { get; set; }

    public ChatClientMultiMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt8(Channel);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Channel = reader.ReadInt8();
    }
}