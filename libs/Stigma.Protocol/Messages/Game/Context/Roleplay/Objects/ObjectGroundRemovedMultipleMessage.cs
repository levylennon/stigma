namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Objects;

public sealed class ObjectGroundRemovedMultipleMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5944;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<short> Cells { get; set; }

    public ObjectGroundRemovedMultipleMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
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
        var cellsCount = reader.ReadInt16();
        var cells = new short[cellsCount];
        for (var i = 0; i < cellsCount; i++) cells[i] = reader.ReadInt16();
        Cells = cells;
    }
}