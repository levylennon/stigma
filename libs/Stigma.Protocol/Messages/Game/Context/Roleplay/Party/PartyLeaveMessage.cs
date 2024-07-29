namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Party;

public sealed class PartyLeaveMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5594;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public PartyLeaveMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}