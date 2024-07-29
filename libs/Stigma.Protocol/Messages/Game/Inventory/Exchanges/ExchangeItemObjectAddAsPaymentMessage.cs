namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeItemObjectAddAsPaymentMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5766;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte PaymentType { get; set; }

    public required bool BAdd { get; set; }

    public required int ObjectToMoveId { get; set; }

    public required int Quantity { get; set; }

    public ExchangeItemObjectAddAsPaymentMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(PaymentType);
        writer.WriteBoolean(BAdd);
        writer.WriteInt32(ObjectToMoveId);
        writer.WriteInt32(Quantity);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        PaymentType = reader.ReadInt8();
        BAdd = reader.ReadBoolean();
        ObjectToMoveId = reader.ReadInt32();
        Quantity = reader.ReadInt32();
    }
}