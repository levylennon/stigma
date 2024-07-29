namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeShowVendorTaxMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5783;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public ExchangeShowVendorTaxMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}