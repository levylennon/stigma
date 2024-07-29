using Stigma.Protocol.Types.Game.Context.Fight;
using Stigma.Protocol.Types.Game.Context.Roleplay;
using Stigma.Protocol.Types.Game.House;
using Stigma.Protocol.Types.Game.Interactive;

namespace Stigma.Protocol.Messages.Game.Context.Roleplay;

public sealed class MapComplementaryInformationsDataMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 226;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int MapId { get; set; }

    public required short SubareaId { get; set; }

    public required IEnumerable<HouseInformations> Houses { get; set; }

    public required IEnumerable<GameRolePlayActorInformations> Actors { get; set; }

    public required IEnumerable<InteractiveElement> InteractiveElements { get; set; }

    public required IEnumerable<StatedElement> StatedElements { get; set; }

    public required IEnumerable<MapObstacle> Obstacles { get; set; }

    public required IEnumerable<FightCommonInformations> Fights { get; set; }

    public MapComplementaryInformationsDataMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(MapId);
        writer.WriteInt16(SubareaId);
        var housesBefore = writer.Position;
        var housesCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Houses)
        {
            writer.WriteUInt16(item.ProtocolId);
            item.Serialize(writer);
            housesCount++;
        }

        var housesAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, housesBefore);
        writer.WriteInt16((short)housesCount);
        writer.Seek(SeekOrigin.Begin, housesAfter);
        var actorsBefore = writer.Position;
        var actorsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Actors)
        {
            writer.WriteUInt16(item.ProtocolId);
            item.Serialize(writer);
            actorsCount++;
        }

        var actorsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, actorsBefore);
        writer.WriteInt16((short)actorsCount);
        writer.Seek(SeekOrigin.Begin, actorsAfter);
        var interactiveElementsBefore = writer.Position;
        var interactiveElementsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in InteractiveElements)
        {
            item.Serialize(writer);
            interactiveElementsCount++;
        }

        var interactiveElementsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, interactiveElementsBefore);
        writer.WriteInt16((short)interactiveElementsCount);
        writer.Seek(SeekOrigin.Begin, interactiveElementsAfter);
        var statedElementsBefore = writer.Position;
        var statedElementsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in StatedElements)
        {
            item.Serialize(writer);
            statedElementsCount++;
        }

        var statedElementsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, statedElementsBefore);
        writer.WriteInt16((short)statedElementsCount);
        writer.Seek(SeekOrigin.Begin, statedElementsAfter);
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
        var fightsBefore = writer.Position;
        var fightsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Fights)
        {
            item.Serialize(writer);
            fightsCount++;
        }

        var fightsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, fightsBefore);
        writer.WriteInt16((short)fightsCount);
        writer.Seek(SeekOrigin.Begin, fightsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        MapId = reader.ReadInt32();
        SubareaId = reader.ReadInt16();
        var housesCount = reader.ReadInt16();
        var houses = new HouseInformations[housesCount];
        for (var i = 0; i < housesCount; i++)
        {
            var entry = DofusTypeFactory.CreateInstance<HouseInformations>(reader.ReadUInt16());
            entry.Deserialize(reader);
            houses[i] = entry;
        }

        Houses = houses;
        var actorsCount = reader.ReadInt16();
        var actors = new GameRolePlayActorInformations[actorsCount];
        for (var i = 0; i < actorsCount; i++)
        {
            var entry = DofusTypeFactory.CreateInstance<GameRolePlayActorInformations>(reader.ReadUInt16());
            entry.Deserialize(reader);
            actors[i] = entry;
        }

        Actors = actors;
        var interactiveElementsCount = reader.ReadInt16();
        var interactiveElements = new InteractiveElement[interactiveElementsCount];
        for (var i = 0; i < interactiveElementsCount; i++)
        {
            var entry = new InteractiveElement();
            entry.Deserialize(reader);
            interactiveElements[i] = entry;
        }

        InteractiveElements = interactiveElements;
        var statedElementsCount = reader.ReadInt16();
        var statedElements = new StatedElement[statedElementsCount];
        for (var i = 0; i < statedElementsCount; i++)
        {
            var entry = new StatedElement();
            entry.Deserialize(reader);
            statedElements[i] = entry;
        }

        StatedElements = statedElements;
        var obstaclesCount = reader.ReadInt16();
        var obstacles = new MapObstacle[obstaclesCount];
        for (var i = 0; i < obstaclesCount; i++)
        {
            var entry = new MapObstacle();
            entry.Deserialize(reader);
            obstacles[i] = entry;
        }

        Obstacles = obstacles;
        var fightsCount = reader.ReadInt16();
        var fights = new FightCommonInformations[fightsCount];
        for (var i = 0; i < fightsCount; i++)
        {
            var entry = new FightCommonInformations();
            entry.Deserialize(reader);
            fights[i] = entry;
        }

        Fights = fights;
    }
}