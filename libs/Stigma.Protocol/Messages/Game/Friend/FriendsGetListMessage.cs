namespace Stigma.Protocol.Messages.Game.Friend;

public sealed class FriendsGetListMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 4001;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public FriendsGetListMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}