namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeBidSearchOkMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5802;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public ExchangeBidSearchOkMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}