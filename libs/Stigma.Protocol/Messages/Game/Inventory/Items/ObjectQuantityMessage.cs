namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public sealed class ObjectQuantityMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 3023;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int ObjectUID { get; set; }

    public required int Quantity { get; set; }

    public ObjectQuantityMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(ObjectUID);
        writer.WriteInt32(Quantity);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ObjectUID = reader.ReadInt32();
        Quantity = reader.ReadInt32();
    }
}