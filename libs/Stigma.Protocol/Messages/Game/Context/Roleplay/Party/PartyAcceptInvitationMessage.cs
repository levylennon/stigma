namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Party;

public sealed class PartyAcceptInvitationMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5580;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public PartyAcceptInvitationMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}