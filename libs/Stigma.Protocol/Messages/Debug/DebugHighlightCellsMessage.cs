namespace Stigma.Protocol.Messages.Debug;

public sealed class DebugHighlightCellsMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 2001;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Color { get; set; }

    public required IEnumerable<short> Cells { get; set; }

    public DebugHighlightCellsMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Color);
        var cellsBefore = writer.Position;
        var cellsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Cells)
        {
            writer.WriteInt16(item);
            cellsCount++;
        }

        var cellsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, cellsBefore);
        writer.WriteInt16((short)cellsCount);
        writer.Seek(SeekOrigin.Begin, cellsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Color = reader.ReadInt32();
        var cellsCount = reader.ReadInt16();
        var cells = new short[cellsCount];
        for (var i = 0; i < cellsCount; i++) cells[i] = reader.ReadInt16();
        Cells = cells;
    }
}