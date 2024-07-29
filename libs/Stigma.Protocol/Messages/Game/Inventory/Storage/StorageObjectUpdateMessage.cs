using Stigma.Protocol.Types.Game.Data.Items;

namespace Stigma.Protocol.Messages.Game.Inventory.Storage;

public sealed class StorageObjectUpdateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5647;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required ObjectItem Object { get; set; }

    public StorageObjectUpdateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        Object.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Object = new ObjectItem();
        Object.Deserialize(reader);
    }
}