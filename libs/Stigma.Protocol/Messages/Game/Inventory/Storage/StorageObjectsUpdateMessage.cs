using Stigma.Protocol.Types.Game.Data.Items;

namespace Stigma.Protocol.Messages.Game.Inventory.Storage;

public sealed class StorageObjectsUpdateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6036;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<ObjectItem> ObjectList { get; set; }

    public StorageObjectsUpdateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var objectListBefore = writer.Position;
        var objectListCount = 0;
        writer.WriteInt16(0);
        foreach (var item in ObjectList)
        {
            item.Serialize(writer);
            objectListCount++;
        }

        var objectListAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, objectListBefore);
        writer.WriteInt16((short)objectListCount);
        writer.Seek(SeekOrigin.Begin, objectListAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var objectListCount = reader.ReadInt16();
        var objectList = new ObjectItem[objectListCount];
        for (var i = 0; i < objectListCount; i++)
        {
            var entry = new ObjectItem();
            entry.Deserialize(reader);
            objectList[i] = entry;
        }

        ObjectList = objectList;
    }
}