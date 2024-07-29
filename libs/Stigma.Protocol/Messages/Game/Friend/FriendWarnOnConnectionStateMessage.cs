namespace Stigma.Protocol.Messages.Game.Friend;

public sealed class FriendWarnOnConnectionStateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5630;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Enable { get; set; }

    public FriendWarnOnConnectionStateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(Enable);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Enable = reader.ReadBoolean();
    }
}