using Stigma.Protocol.Types.Game.Data.Items;

namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeShopStockMultiMovementUpdatedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6038;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<ObjectItemToSell> ObjectInfoList { get; set; }

    public ExchangeShopStockMultiMovementUpdatedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var objectInfoListBefore = writer.Position;
        var objectInfoListCount = 0;
        writer.WriteInt16(0);
        foreach (var item in ObjectInfoList)
        {
            item.Serialize(writer);
            objectInfoListCount++;
        }

        var objectInfoListAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, objectInfoListBefore);
        writer.WriteInt16((short)objectInfoListCount);
        writer.Seek(SeekOrigin.Begin, objectInfoListAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var objectInfoListCount = reader.ReadInt16();
        var objectInfoList = new ObjectItemToSell[objectInfoListCount];
        for (var i = 0; i < objectInfoListCount; i++)
        {
            var entry = new ObjectItemToSell();
            entry.Deserialize(reader);
            objectInfoList[i] = entry;
        }

        ObjectInfoList = objectInfoList;
    }
}