using Stigma.Protocol.Types.Game.Data.Items;

namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeGuildTaxCollectorGetMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5762;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string CollectorName { get; set; }

    public required short WorldX { get; set; }

    public required short WorldY { get; set; }

    public required int MapId { get; set; }

    public required string UserName { get; set; }

    public required double Experience { get; set; }

    public required IEnumerable<ObjectItemQuantity> ObjectsInfos { get; set; }

    public ExchangeGuildTaxCollectorGetMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUtf(CollectorName);
        writer.WriteInt16(WorldX);
        writer.WriteInt16(WorldY);
        writer.WriteInt32(MapId);
        writer.WriteUtf(UserName);
        writer.WriteDouble(Experience);
        var objectsInfosBefore = writer.Position;
        var objectsInfosCount = 0;
        writer.WriteInt16(0);
        foreach (var item in ObjectsInfos)
        {
            item.Serialize(writer);
            objectsInfosCount++;
        }

        var objectsInfosAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, objectsInfosBefore);
        writer.WriteInt16((short)objectsInfosCount);
        writer.Seek(SeekOrigin.Begin, objectsInfosAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        CollectorName = reader.ReadUtf();
        WorldX = reader.ReadInt16();
        WorldY = reader.ReadInt16();
        MapId = reader.ReadInt32();
        UserName = reader.ReadUtf();
        Experience = reader.ReadDouble();
        var objectsInfosCount = reader.ReadInt16();
        var objectsInfos = new ObjectItemQuantity[objectsInfosCount];
        for (var i = 0; i < objectsInfosCount; i++)
        {
            var entry = new ObjectItemQuantity();
            entry.Deserialize(reader);
            objectsInfos[i] = entry;
        }

        ObjectsInfos = objectsInfos;
    }
}