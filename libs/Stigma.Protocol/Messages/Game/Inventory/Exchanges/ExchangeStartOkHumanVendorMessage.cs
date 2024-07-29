using Stigma.Protocol.Types.Game.Data.Items;

namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeStartOkHumanVendorMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5767;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int SellerId { get; set; }

    public required IEnumerable<ObjectItemToSell> ObjectsInfos { get; set; }

    public ExchangeStartOkHumanVendorMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(SellerId);
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
        SellerId = reader.ReadInt32();
        var objectsInfosCount = reader.ReadInt16();
        var objectsInfos = new ObjectItemToSell[objectsInfosCount];
        for (var i = 0; i < objectsInfosCount; i++)
        {
            var entry = new ObjectItemToSell();
            entry.Deserialize(reader);
            objectsInfos[i] = entry;
        }

        ObjectsInfos = objectsInfos;
    }
}