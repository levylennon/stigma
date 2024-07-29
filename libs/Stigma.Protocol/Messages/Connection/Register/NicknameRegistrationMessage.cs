namespace Stigma.Protocol.Messages.Connection.Register;

public sealed class NicknameRegistrationMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5640;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public NicknameRegistrationMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}