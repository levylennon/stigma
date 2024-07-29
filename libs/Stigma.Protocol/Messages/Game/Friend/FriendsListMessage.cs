using Stigma.Protocol.Types.Game.Friend;

namespace Stigma.Protocol.Messages.Game.Friend;

public class FriendsListMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 4002;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<FriendInformations> FriendsList { get; set; }

    public FriendsListMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var friendsListBefore = writer.Position;
        var friendsListCount = 0;
        writer.WriteInt16(0);
        foreach (var item in FriendsList)
        {
            writer.WriteUInt16(item.ProtocolId);
            item.Serialize(writer);
            friendsListCount++;
        }

        var friendsListAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, friendsListBefore);
        writer.WriteInt16((short)friendsListCount);
        writer.Seek(SeekOrigin.Begin, friendsListAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var friendsListCount = reader.ReadInt16();
        var friendsList = new FriendInformations[friendsListCount];
        for (var i = 0; i < friendsListCount; i++)
        {
            var entry = DofusTypeFactory.CreateInstance<FriendInformations>(reader.ReadUInt16());
            entry.Deserialize(reader);
            friendsList[i] = entry;
        }

        FriendsList = friendsList;
    }
}