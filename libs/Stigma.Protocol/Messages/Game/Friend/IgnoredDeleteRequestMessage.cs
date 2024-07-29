namespace Stigma.Protocol.Messages.Game.Friend;

public sealed class IgnoredDeleteRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5680;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string Name { get; set; }

    public IgnoredDeleteRequestMessage()
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