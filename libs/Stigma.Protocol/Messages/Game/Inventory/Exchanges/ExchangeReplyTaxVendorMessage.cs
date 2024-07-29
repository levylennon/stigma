namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeReplyTaxVendorMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5787;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int ObjectValue { get; set; }

    public required int TaxRate { get; set; }

    public required int TotalTaxValue { get; set; }

    public ExchangeReplyTaxVendorMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(ObjectValue);
        writer.WriteInt32(TaxRate);
        writer.WriteInt32(TotalTaxValue);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ObjectValue = reader.ReadInt32();
        TaxRate = reader.ReadInt32();
        TotalTaxValue = reader.ReadInt32();
    }
}