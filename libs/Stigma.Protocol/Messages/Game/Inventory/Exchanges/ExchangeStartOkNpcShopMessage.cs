using Stigma.Protocol.Types.Game.Data.Items;

namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeStartOkNpcShopMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5761;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int NpcSellerId { get; set; }

    public required IEnumerable<ObjectItemToSellInNpcShop> ObjectsInfos { get; set; }

    public ExchangeStartOkNpcShopMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(NpcSellerId);
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
        NpcSellerId = reader.ReadInt32();
        var objectsInfosCount = reader.ReadInt16();
        var objectsInfos = new ObjectItemToSellInNpcShop[objectsInfosCount];
        for (var i = 0; i < objectsInfosCount; i++)
        {
            var entry = new ObjectItemToSellInNpcShop();
            entry.Deserialize(reader);
            objectsInfos[i] = entry;
        }

        ObjectsInfos = objectsInfos;
    }
}