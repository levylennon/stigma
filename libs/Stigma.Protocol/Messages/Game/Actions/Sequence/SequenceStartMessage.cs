namespace Stigma.Protocol.Messages.Game.Actions.Sequence;

public sealed class SequenceStartMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 955;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int AuthorId { get; set; }

    public required sbyte SequenceType { get; set; }

    public SequenceStartMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(AuthorId);
        writer.WriteInt8(SequenceType);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        AuthorId = reader.ReadInt32();
        SequenceType = reader.ReadInt8();
    }
}