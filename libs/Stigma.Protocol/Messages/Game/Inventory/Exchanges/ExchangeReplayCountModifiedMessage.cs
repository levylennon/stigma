namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeReplayCountModifiedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6023;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Count { get; set; }

    public ExchangeReplayCountModifiedMessage()
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