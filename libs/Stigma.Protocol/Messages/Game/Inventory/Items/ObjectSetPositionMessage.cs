namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public sealed class ObjectSetPositionMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 3021;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int ObjectUID { get; set; }

    public required byte Position { get; set; }

    public required int Quantity { get; set; }

    public ObjectSetPositionMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(ObjectUID);
        writer.WriteUInt8(Position);
        writer.WriteInt32(Quantity);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ObjectUID = reader.ReadInt32();
        Position = reader.ReadUInt8();
        Quantity = reader.ReadInt32();
    }
}