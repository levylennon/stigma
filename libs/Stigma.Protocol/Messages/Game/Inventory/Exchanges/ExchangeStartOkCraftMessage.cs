namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public class ExchangeStartOkCraftMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5813;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public ExchangeStartOkCraftMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}