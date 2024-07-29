namespace Stigma.Protocol.Messages.Authorized;

public class AdminCommandMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 76;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string Content { get; set; }

    public AdminCommandMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUtf(Content);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Content = reader.ReadUtf();
    }
}