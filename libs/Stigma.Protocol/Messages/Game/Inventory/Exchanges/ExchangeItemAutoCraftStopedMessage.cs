namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeItemAutoCraftStopedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5810;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Reason { get; set; }

    public ExchangeItemAutoCraftStopedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(Reason);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Reason = reader.ReadInt8();
    }
}