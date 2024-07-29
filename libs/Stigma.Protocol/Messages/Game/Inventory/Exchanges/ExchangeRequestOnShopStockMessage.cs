namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeRequestOnShopStockMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5753;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public ExchangeRequestOnShopStockMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}