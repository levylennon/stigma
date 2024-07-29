namespace Stigma.Protocol.Messages.Game.Friend;

public sealed class IgnoredAddFailureMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5679;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Reason { get; set; }

    public IgnoredAddFailureMessage()
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