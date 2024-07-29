namespace Stigma.Protocol.Messages.Security;

public sealed class ClientKeyMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5607;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string Key { get; set; }

    public ClientKeyMessage()
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