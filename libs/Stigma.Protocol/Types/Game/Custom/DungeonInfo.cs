namespace Stigma.Protocol.Types.Game.Custom;

public sealed class DungeonInfo : DofusType
{
    public new const ushort ProtocolTypeId = 6400;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int DungeonId { get; set; }

    public int Level { get; set; }

    public int RecordTime { get; set; }

    public DungeonInfo()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(DungeonId);
        writer.WriteInt32(Level);
        writer.WriteInt32(RecordTime);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        DungeonId = reader.ReadInt32();
        Level = reader.ReadInt32();
        RecordTime = reader.ReadInt32();
    }
}