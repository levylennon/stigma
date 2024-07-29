using Stigma.Protocol.Messages.Game.Inventory.Items;

namespace Stigma.Protocol.Messages.Game.Inventory.Storage;

public sealed class StorageInventoryContentMessage : InventoryContentMessage
{
    public new const uint ProtocolMessageId = 5646;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public StorageInventoryContentMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
    }
}