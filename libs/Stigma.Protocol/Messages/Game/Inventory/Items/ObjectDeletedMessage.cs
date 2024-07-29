namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public sealed class ObjectDeletedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 3024;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int ObjectUID { get; set; }

    public ObjectDeletedMessage()
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