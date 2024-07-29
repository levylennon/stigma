namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeItemGoldAddAsPaymentMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5770;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte PaymentType { get; set; }

    public required int Quantity { get; set; }

    public ExchangeItemGoldAddAsPaymentMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(PaymentType);
        writer.WriteInt32(Quantity);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        PaymentType = reader.ReadInt8();
        Quantity = reader.ReadInt32();
    }
}