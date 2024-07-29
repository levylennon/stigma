namespace Stigma.Protocol.Types.Game.Interactive;

public sealed class MapObstacle : DofusType
{
    public new const ushort ProtocolTypeId = 200;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short ObstacleCellId { get; set; }

    public sbyte State { get; set; }

    public MapObstacle()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(ObstacleCellId);
        writer.WriteInt8(State);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ObstacleCellId = reader.ReadInt16();
        State = reader.ReadInt8();
    }
}