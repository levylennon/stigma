namespace Stigma.Protocol.Messages.Game.Friend;

public sealed class FriendAddRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 4004;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string Name { get; set; }

    public FriendAddRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUtf(Name);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Name = reader.ReadUtf();
    }
}