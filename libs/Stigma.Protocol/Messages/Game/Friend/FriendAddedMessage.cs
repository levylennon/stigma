using Stigma.Protocol.Types.Game.Friend;

namespace Stigma.Protocol.Messages.Game.Friend;

public sealed class FriendAddedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5599;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required FriendInformations FriendAdded { get; set; }

    public FriendAddedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUInt16(FriendAdded.ProtocolId);
        FriendAdded.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FriendAdded = DofusTypeFactory.CreateInstance<FriendInformations>(reader.ReadUInt16());
        FriendAdded.Deserialize(reader);
    }
}