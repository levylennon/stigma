namespace Stigma.Protocol.Messages.Game.Friend;

public sealed class IgnoredAddRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5673;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string Name { get; set; }

    public IgnoredAddRequestMessage()
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