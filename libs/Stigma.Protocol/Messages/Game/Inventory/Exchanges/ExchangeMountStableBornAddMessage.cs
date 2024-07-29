namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeMountStableBornAddMessage : ExchangeMountStableAddMessage
{
    public new const uint ProtocolMessageId = 5966;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public ExchangeMountStableBornAddMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
    }
}