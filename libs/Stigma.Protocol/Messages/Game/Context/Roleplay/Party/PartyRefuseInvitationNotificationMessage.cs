namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Party;

public sealed class PartyRefuseInvitationNotificationMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5596;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public PartyRefuseInvitationNotificationMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}