namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Party;

public sealed class PartyInvitationRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5585;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string Name { get; set; }

    public PartyInvitationRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUtf(Name);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Name = reader.ReadUtf();
    }
}