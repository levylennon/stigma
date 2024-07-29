namespace Stigma.Protocol.Types.Game.Data.Items;

public sealed class ObjectItemQuantity : Item
{
    public new const ushort ProtocolTypeId = 119;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int ObjectUID { get; set; }

    public int Quantity { get; set; }

    public ObjectItemQuantity()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(ObjectUID);
        writer.WriteInt32(Quantity);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        ObjectUID = reader.ReadInt32();
        Quantity = reader.ReadInt32();
    }
}