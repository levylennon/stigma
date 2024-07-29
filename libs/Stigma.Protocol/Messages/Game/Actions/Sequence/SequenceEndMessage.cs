namespace Stigma.Protocol.Messages.Game.Actions.Sequence;

public sealed class SequenceEndMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 956;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short ActionId { get; set; }

    public required int AuthorId { get; set; }

    public required sbyte SequenceType { get; set; }

    public SequenceEndMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(ActionId);
        writer.WriteInt32(AuthorId);
        writer.WriteInt8(SequenceType);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ActionId = reader.ReadInt16();
        AuthorId = reader.ReadInt32();
        SequenceType = reader.ReadInt8();
    }
}