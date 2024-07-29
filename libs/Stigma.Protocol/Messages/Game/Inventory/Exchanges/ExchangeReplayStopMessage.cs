namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeReplayStopMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6001;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public ExchangeReplayStopMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}