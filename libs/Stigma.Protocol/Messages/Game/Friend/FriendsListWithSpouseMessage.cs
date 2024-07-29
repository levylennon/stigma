using Stigma.Protocol.Types.Game.Friend;

namespace Stigma.Protocol.Messages.Game.Friend;

public sealed class FriendsListWithSpouseMessage : FriendsListMessage
{
    public new const uint ProtocolMessageId = 5931;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required FriendSpouseInformations Spouse { get; set; }

    public FriendsListWithSpouseMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUInt16(Spouse.ProtocolId);
        Spouse.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Spouse = DofusTypeFactory.CreateInstance<FriendSpouseInformations>(reader.ReadUInt16());
        Spouse.Deserialize(reader);
    }
}