namespace Stigma.Protocol.Types.Game.Context;

public sealed class MapCoordinatesExtended : MapCoordinates
{
    public new const ushort ProtocolTypeId = 176;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int MapId { get; set; }

    public MapCoordinatesExtended()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(MapId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        MapId = reader.ReadInt32();
    }
}