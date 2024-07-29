namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeSellOkMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5792;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public ExchangeSellOkMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}