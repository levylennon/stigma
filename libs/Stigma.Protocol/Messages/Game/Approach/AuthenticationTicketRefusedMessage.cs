namespace Stigma.Protocol.Messages.Game.Approach;

public sealed class AuthenticationTicketRefusedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 112;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public AuthenticationTicketRefusedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}