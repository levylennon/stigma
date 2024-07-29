namespace Stigma.Protocol.Types.Game.Actions.Fight;

public sealed class GameActionMarkedCell : DofusType
{
    public new const ushort ProtocolTypeId = 85;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short CellId { get; set; }

    public sbyte ZoneSize { get; set; }

    public int CellColor { get; set; }

    public GameActionMarkedCell()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(CellId);
        writer.WriteInt8(ZoneSize);
        writer.WriteInt32(CellColor);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        CellId = reader.ReadInt16();
        ZoneSize = reader.ReadInt8();
        CellColor = reader.ReadInt32();
    }
}