namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Party;

public sealed class PartyRefuseInvitationMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5582;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public PartyRefuseInvitationMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}