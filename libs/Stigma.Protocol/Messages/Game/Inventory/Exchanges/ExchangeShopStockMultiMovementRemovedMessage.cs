namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeShopStockMultiMovementRemovedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6037;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<int> ObjectIdList { get; set; }

    public ExchangeShopStockMultiMovementRemovedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var objectIdListBefore = writer.Position;
        var objectIdListCount = 0;
        writer.WriteInt16(0);
        foreach (var item in ObjectIdList)
        {
            writer.WriteInt32(item);
            objectIdListCount++;
        }

        var objectIdListAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, objectIdListBefore);
        writer.WriteInt16((short)objectIdListCount);
        writer.Seek(SeekOrigin.Begin, objectIdListAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var objectIdListCount = reader.ReadInt16();
        var objectIdList = new int[objectIdListCount];
        for (var i = 0; i < objectIdListCount; i++) objectIdList[i] = reader.ReadInt32();
        ObjectIdList = objectIdList;
    }
}