using Stigma.Protocol.Types.Game.Data.Items;

namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public class InventoryContentMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 3016;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<ObjectItem> Objects { get; set; }

    public required int Kamas { get; set; }

    public InventoryContentMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var objectsBefore = writer.Position;
        var objectsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Objects)
        {
            item.Serialize(writer);
            objectsCount++;
        }

        var objectsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, objectsBefore);
        writer.WriteInt16((short)objectsCount);
        writer.Seek(SeekOrigin.Begin, objectsAfter);
        writer.WriteInt32(Kamas);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var objectsCount = reader.ReadInt16();
        var objects = new ObjectItem[objectsCount];
        for (var i = 0; i < objectsCount; i++)
        {
            var entry = new ObjectItem();
            entry.Deserialize(reader);
            objects[i] = entry;
        }

        Objects = objects;
        Kamas = reader.ReadInt32();
    }
}