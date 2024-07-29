namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeMountStableErrorMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5981;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public ExchangeMountStableErrorMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}