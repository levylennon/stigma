namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Objects;

public sealed class ObjectGroundListAddedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5925;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<short> Cells { get; set; }

    public required IEnumerable<int> ReferenceIds { get; set; }

    public ObjectGroundListAddedMessage()
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
        var referenceIdsBefore = writer.Position;
        var referenceIdsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in ReferenceIds)
        {
            writer.WriteInt32(item);
            referenceIdsCount++;
        }

        var referenceIdsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, referenceIdsBefore);
        writer.WriteInt16((short)referenceIdsCount);
        writer.Seek(SeekOrigin.Begin, referenceIdsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var cellsCount = reader.ReadInt16();
        var cells = new short[cellsCount];
        for (var i = 0; i < cellsCount; i++) cells[i] = reader.ReadInt16();
        Cells = cells;
        var referenceIdsCount = reader.ReadInt16();
        var referenceIds = new int[referenceIdsCount];
        for (var i = 0; i < referenceIdsCount; i++) referenceIds[i] = reader.ReadInt32();
        ReferenceIds = referenceIds;
    }
}