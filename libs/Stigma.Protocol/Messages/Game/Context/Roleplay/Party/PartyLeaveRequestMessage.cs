namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Party;

public sealed class PartyLeaveRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5593;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public PartyLeaveRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}