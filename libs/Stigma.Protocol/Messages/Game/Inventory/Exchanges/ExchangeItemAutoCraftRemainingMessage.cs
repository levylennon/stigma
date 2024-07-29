namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeItemAutoCraftRemainingMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6015;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Count { get; set; }

    public ExchangeItemAutoCraftRemainingMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Count);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Count = reader.ReadInt32();
    }
}