namespace Stigma.Protocol.Messages.Authorized;

public sealed class AdminQuietCommandMessage : AdminCommandMessage
{
    public new const uint ProtocolMessageId = 5662;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public AdminQuietCommandMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
    }
}