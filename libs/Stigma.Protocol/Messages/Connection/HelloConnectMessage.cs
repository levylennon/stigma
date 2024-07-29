namespace Stigma.Protocol.Messages.Connection;

public sealed class HelloConnectMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 3;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string Key { get; set; }

    public HelloConnectMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUtf(Key);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Key = reader.ReadUtf();
    }
}