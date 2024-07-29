namespace Stigma.Protocol.Types.Game.Context;

public class MapCoordinates : DofusType
{
    public new const ushort ProtocolTypeId = 174;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short WorldX { get; set; }

    public short WorldY { get; set; }

    public MapCoordinates()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(WorldX);
        writer.WriteInt16(WorldY);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        WorldX = reader.ReadInt16();
        WorldY = reader.ReadInt16();
    }
}