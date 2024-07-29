namespace Stigma.Protocol.Messages.Game.Friend;

public sealed class FriendDeleteResultMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5601;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Success { get; set; }

    public required string Name { get; set; }

    public FriendDeleteResultMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(Success);
        writer.WriteUtf(Name);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Success = reader.ReadBoolean();
        Name = reader.ReadUtf();
    }
}