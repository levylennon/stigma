namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeBuyOkMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5759;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public ExchangeBuyOkMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}