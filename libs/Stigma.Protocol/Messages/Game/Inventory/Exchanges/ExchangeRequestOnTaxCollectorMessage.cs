namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeRequestOnTaxCollectorMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5779;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int TaxCollectorId { get; set; }

    public ExchangeRequestOnTaxCollectorMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(TaxCollectorId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        TaxCollectorId = reader.ReadInt32();
    }
}