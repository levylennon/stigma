using Stigma.Protocol.Types.Game.Data.Items;

namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public sealed class ObjectsAddedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6033;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<ObjectItem> Object { get; set; }

    public ObjectsAddedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var objectBefore = writer.Position;
        var objectCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Object)
        {
            item.Serialize(writer);
            objectCount++;
        }

        var objectAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, objectBefore);
        writer.WriteInt16((short)objectCount);
        writer.Seek(SeekOrigin.Begin, objectAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var objectCount = reader.ReadInt16();
        var @object = new ObjectItem[objectCount];
        for (var i = 0; i < objectCount; i++)
        {
            var entry = new ObjectItem();
            entry.Deserialize(reader);
            @object[i] = entry;
        }

        Object = @object;
    }
}