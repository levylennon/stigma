namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public class ExchangeObjectMoveMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5518;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int ObjectUID { get; set; }

    public required short Quantity { get; set; }

    public ExchangeObjectMoveMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(ObjectUID);
        writer.WriteInt16(Quantity);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ObjectUID = reader.ReadInt32();
        Quantity = reader.ReadInt16();
    }
}