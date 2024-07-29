namespace Stigma.Protocol.Messages.Game.Friend;

public sealed class FriendAddFailureMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5600;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Reason { get; set; }

    public FriendAddFailureMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(Reason);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Reason = reader.ReadInt8();
    }
}