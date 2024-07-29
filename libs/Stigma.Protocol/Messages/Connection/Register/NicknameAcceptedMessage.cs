namespace Stigma.Protocol.Messages.Connection.Register;

public sealed class NicknameAcceptedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5641;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public NicknameAcceptedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}