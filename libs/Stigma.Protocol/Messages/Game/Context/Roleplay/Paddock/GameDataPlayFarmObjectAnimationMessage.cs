namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Paddock;

public sealed class GameDataPlayFarmObjectAnimationMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6026;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<short> CellId { get; set; }

    public GameDataPlayFarmObjectAnimationMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var cellIdBefore = writer.Position;
        var cellIdCount = 0;
        writer.WriteInt16(0);
        foreach (var item in CellId)
        {
            writer.WriteInt16(item);
            cellIdCount++;
        }

        var cellIdAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, cellIdBefore);
        writer.WriteInt16((short)cellIdCount);
        writer.Seek(SeekOrigin.Begin, cellIdAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var cellIdCount = reader.ReadInt16();
        var cellId = new short[cellIdCount];
        for (var i = 0; i < cellIdCount; i++) cellId[i] = reader.ReadInt16();
        CellId = cellId;
    }
}