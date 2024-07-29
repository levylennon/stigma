namespace Stigma.Protocol.Messages.Game.Friend;

public sealed class FriendWarnOnLevelGainStateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6078;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Enable { get; set; }

    public FriendWarnOnLevelGainStateMessage()
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