namespace Stigma.Protocol.Messages.Game.Chat;

public class ChatAbstractServerMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 880;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Channel { get; set; }

    public required string Content { get; set; }

    public required int Timestamp { get; set; }

    public required string Fingerprint { get; set; }

    public ChatAbstractServerMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(Channel);
        writer.WriteUtf(Content);
        writer.WriteInt32(Timestamp);
        writer.WriteUtf(Fingerprint);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Channel = reader.ReadInt8();
        Content = reader.ReadUtf();
        Timestamp = reader.ReadInt32();
        Fingerprint = reader.ReadUtf();
    }
}