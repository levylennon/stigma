namespace Stigma.Protocol.Messages.Game.Inventory.Storage;

public sealed class StorageObjectRemoveMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5648;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int ObjectUID { get; set; }

    public StorageObjectRemoveMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(ObjectUID);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ObjectUID = reader.ReadInt32();
    }
}