namespace Stigma.Protocol.Messages.Authorized;

public sealed class ConsoleMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 75;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Type { get; set; }

    public required string Content { get; set; }

    public ConsoleMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(Type);
        writer.WriteUtf(Content);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Type = reader.ReadInt8();
        Content = reader.ReadUtf();
    }
}