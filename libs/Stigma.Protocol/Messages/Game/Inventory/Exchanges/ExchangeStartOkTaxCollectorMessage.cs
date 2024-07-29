using Stigma.Protocol.Types.Game.Data.Items;

namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeStartOkTaxCollectorMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5780;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int CollectorId { get; set; }

    public required IEnumerable<ObjectItem> ObjectsInfos { get; set; }

    public required int GoldInfo { get; set; }

    public ExchangeStartOkTaxCollectorMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(CollectorId);
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
        writer.WriteInt32(GoldInfo);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        CollectorId = reader.ReadInt32();
        var objectsInfosCount = reader.ReadInt16();
        var objectsInfos = new ObjectItem[objectsInfosCount];
        for (var i = 0; i < objectsInfosCount; i++)
        {
            var entry = new ObjectItem();
            entry.Deserialize(reader);
            objectsInfos[i] = entry;
        }

        ObjectsInfos = objectsInfos;
        GoldInfo = reader.ReadInt32();
    }
}