using Stigma.Protocol.Types.Game.Friend;

namespace Stigma.Protocol.Messages.Game.Friend;

public sealed class FriendUpdateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5924;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required FriendInformations FriendUpdated { get; set; }

    public FriendUpdateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUInt16(FriendUpdated.ProtocolId);
        FriendUpdated.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FriendUpdated = DofusTypeFactory.CreateInstance<FriendInformations>(reader.ReadUInt16());
        FriendUpdated.Deserialize(reader);
    }
}