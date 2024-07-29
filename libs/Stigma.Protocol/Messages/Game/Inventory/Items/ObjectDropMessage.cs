namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public sealed class ObjectDropMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 3005;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int ObjectUID { get; set; }

    public required int Quantity { get; set; }

    public ObjectDropMessage()
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