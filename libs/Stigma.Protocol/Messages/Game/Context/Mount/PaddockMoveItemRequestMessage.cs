namespace Stigma.Protocol.Messages.Game.Context.Mount;

public sealed class PaddockMoveItemRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6052;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short OldCellId { get; set; }

    public required short NewCellId { get; set; }

    public PaddockMoveItemRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(OldCellId);
        writer.WriteInt16(NewCellId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        OldCellId = reader.ReadInt16();
        NewCellId = reader.ReadInt16();
    }
}