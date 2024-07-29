namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeStartAsVendorMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5775;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public ExchangeStartAsVendorMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}