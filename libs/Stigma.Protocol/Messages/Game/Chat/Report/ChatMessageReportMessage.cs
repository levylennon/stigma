namespace Stigma.Protocol.Messages.Game.Chat.Report;

public sealed class ChatMessageReportMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 821;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string SenderName { get; set; }

    public required string Content { get; set; }

    public required int Timestamp { get; set; }

    public required string Fingerprint { get; set; }

    public required sbyte Reason { get; set; }

    public ChatMessageReportMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUtf(SenderName);
        writer.WriteUtf(Content);
        writer.WriteInt32(Timestamp);
        writer.WriteUtf(Fingerprint);
        writer.WriteInt8(Reason);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        SenderName = reader.ReadUtf();
        Content = reader.ReadUtf();
        Timestamp = reader.ReadInt32();
        Fingerprint = reader.ReadUtf();
        Reason = reader.ReadInt8();
    }
}