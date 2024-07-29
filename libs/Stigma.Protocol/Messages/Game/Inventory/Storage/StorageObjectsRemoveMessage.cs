namespace Stigma.Protocol.Messages.Game.Inventory.Storage;

public sealed class StorageObjectsRemoveMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6035;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<int> ObjectUIDList { get; set; }

    public StorageObjectsRemoveMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var objectUIDListBefore = writer.Position;
        var objectUIDListCount = 0;
        writer.WriteInt16(0);
        foreach (var item in ObjectUIDList)
        {
            writer.WriteInt32(item);
            objectUIDListCount++;
        }

        var objectUIDListAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, objectUIDListBefore);
        writer.WriteInt16((short)objectUIDListCount);
        writer.Seek(SeekOrigin.Begin, objectUIDListAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var objectUIDListCount = reader.ReadInt16();
        var objectUIDList = new int[objectUIDListCount];
        for (var i = 0; i < objectUIDListCount; i++) objectUIDList[i] = reader.ReadInt32();
        ObjectUIDList = objectUIDList;
    }
}