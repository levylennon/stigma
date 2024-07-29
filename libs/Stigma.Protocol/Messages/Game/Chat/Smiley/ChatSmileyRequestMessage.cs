namespace Stigma.Protocol.Messages.Game.Chat.Smiley;

public sealed class ChatSmileyRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 800;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte SmileyId { get; set; }

    public ChatSmileyRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(SmileyId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        SmileyId = reader.ReadInt8();
    }
}