namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeRequestOnMountStockMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5986;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public ExchangeRequestOnMountStockMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}