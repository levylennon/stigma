namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public sealed class ObjectsDeletedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6034;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<int> ObjectUID { get; set; }

    public ObjectsDeletedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var objectUIDBefore = writer.Position;
        var objectUIDCount = 0;
        writer.WriteInt16(0);
        foreach (var item in ObjectUID)
        {
            writer.WriteInt32(item);
            objectUIDCount++;
        }

        var objectUIDAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, objectUIDBefore);
        writer.WriteInt16((short)objectUIDCount);
        writer.Seek(SeekOrigin.Begin, objectUIDAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var objectUIDCount = reader.ReadInt16();
        var objectUID = new int[objectUIDCount];
        for (var i = 0; i < objectUIDCount; i++) objectUID[i] = reader.ReadInt32();
        ObjectUID = objectUID;
    }
}