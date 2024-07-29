namespace Stigma.Protocol.Messages.Game.Friend;

public sealed class FriendSetWarnOnLevelGainMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6077;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Enable { get; set; }

    public FriendSetWarnOnLevelGainMessage()
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