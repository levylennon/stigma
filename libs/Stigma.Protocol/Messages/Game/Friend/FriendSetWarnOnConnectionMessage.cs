namespace Stigma.Protocol.Messages.Game.Friend;

public sealed class FriendSetWarnOnConnectionMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5602;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Enable { get; set; }

    public FriendSetWarnOnConnectionMessage()
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