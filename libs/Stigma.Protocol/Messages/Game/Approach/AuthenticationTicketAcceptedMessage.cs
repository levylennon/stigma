namespace Stigma.Protocol.Messages.Game.Approach;

public sealed class AuthenticationTicketAcceptedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 111;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public AuthenticationTicketAcceptedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}