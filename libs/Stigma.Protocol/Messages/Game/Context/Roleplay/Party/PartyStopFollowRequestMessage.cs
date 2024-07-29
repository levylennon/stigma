namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Party;

public sealed class PartyStopFollowRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5574;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public PartyStopFollowRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}