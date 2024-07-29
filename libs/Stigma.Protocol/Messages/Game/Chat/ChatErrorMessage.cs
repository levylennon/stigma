namespace Stigma.Protocol.Messages.Game.Chat;

public sealed class ChatErrorMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 870;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Reason { get; set; }

    public ChatErrorMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(Reason);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Reason = reader.ReadInt8();
    }
}