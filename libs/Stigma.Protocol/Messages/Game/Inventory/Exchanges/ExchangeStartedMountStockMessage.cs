using Stigma.Protocol.Types.Game.Data.Items;

namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeStartedMountStockMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5984;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<ObjectItem> ObjectsInfos { get; set; }

    public ExchangeStartedMountStockMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
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
        var objectsInfosCount = reader.ReadInt16();
        var objectsInfos = new ObjectItem[objectsInfosCount];
        for (var i = 0; i < objectsInfosCount; i++)
        {
            var entry = new ObjectItem();
            entry.Deserialize(reader);
            objectsInfos[i] = entry;
        }

        ObjectsInfos = objectsInfos;
    }
}