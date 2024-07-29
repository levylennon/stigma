using Stigma.Protocol.Types.Game.Actions.Fight;

namespace Stigma.Protocol.Messages.Game.Actions.Fight;

public sealed class GameActionFightMarkCellsMessage : AbstractGameActionMessage
{
    public new const uint ProtocolMessageId = 5540;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short MarkId { get; set; }

    public required sbyte MarkType { get; set; }

    public required IEnumerable<GameActionMarkedCell> Cells { get; set; }

    public GameActionFightMarkCellsMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(MarkId);
        writer.WriteInt8(MarkType);
        var cellsBefore = writer.Position;
        var cellsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Cells)
        {
            item.Serialize(writer);
            cellsCount++;
        }

        var cellsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, cellsBefore);
        writer.WriteInt16((short)cellsCount);
        writer.Seek(SeekOrigin.Begin, cellsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        MarkId = reader.ReadInt16();
        MarkType = reader.ReadInt8();
        var cellsCount = reader.ReadInt16();
        var cells = new GameActionMarkedCell[cellsCount];
        for (var i = 0; i < cellsCount; i++)
        {
            var entry = new GameActionMarkedCell();
            entry.Deserialize(reader);
            cells[i] = entry;
        }

        Cells = cells;
    }
}