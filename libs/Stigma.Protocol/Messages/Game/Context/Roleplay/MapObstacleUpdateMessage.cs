using Stigma.Protocol.Types.Game.Interactive;

namespace Stigma.Protocol.Messages.Game.Context.Roleplay;

public sealed class MapObstacleUpdateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6051;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<MapObstacle> Obstacles { get; set; }

    public MapObstacleUpdateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var obstaclesBefore = writer.Position;
        var obstaclesCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Obstacles)
        {
            item.Serialize(writer);
            obstaclesCount++;
        }

        var obstaclesAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, obstaclesBefore);
        writer.WriteInt16((short)obstaclesCount);
        writer.Seek(SeekOrigin.Begin, obstaclesAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var obstaclesCount = reader.ReadInt16();
        var obstacles = new MapObstacle[obstaclesCount];
        for (var i = 0; i < obstaclesCount; i++)
        {
            var entry = new MapObstacle();
            entry.Deserialize(reader);
            obstacles[i] = entry;
        }

        Obstacles = obstacles;
    }
}