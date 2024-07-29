namespace Stigma.Protocol.Messages.Game.Chat.Smiley;

public sealed class ChatSmileyMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 801;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int EntityId { get; set; }

    public required sbyte SmileyId { get; set; }

    public ChatSmileyMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(EntityId);
        writer.WriteInt8(SmileyId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        EntityId = reader.ReadInt32();
        SmileyId = reader.ReadInt8();
    }
}