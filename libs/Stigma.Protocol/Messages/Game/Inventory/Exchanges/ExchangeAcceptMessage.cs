namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeAcceptMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5508;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public ExchangeAcceptMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}