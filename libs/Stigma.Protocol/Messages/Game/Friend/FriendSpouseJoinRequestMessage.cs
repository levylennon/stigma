namespace Stigma.Protocol.Messages.Game.Friend;

public sealed class FriendSpouseJoinRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5604;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public FriendSpouseJoinRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}