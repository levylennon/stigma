namespace Stigma.Protocol.Messages.Game.Approach;

public sealed class AuthenticationTicketMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 110;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string Ticket { get; set; }

    public required string Lang { get; set; }

    public AuthenticationTicketMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUtf(Ticket);
        writer.WriteUtf(Lang);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Ticket = reader.ReadUtf();
        Lang = reader.ReadUtf();
    }
}