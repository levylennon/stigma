namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeRequestedTradeMessage : ExchangeRequestedMessage
{
    public new const uint ProtocolMessageId = 5523;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Source { get; set; }

    public required int Target { get; set; }

    public ExchangeRequestedTradeMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(Source);
        writer.WriteInt32(Target);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Source = reader.ReadInt32();
        Target = reader.ReadInt32();
    }
}