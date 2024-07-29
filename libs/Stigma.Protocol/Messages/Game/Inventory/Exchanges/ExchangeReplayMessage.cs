namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeReplayMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6002;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Count { get; set; }

    public ExchangeReplayMessage()
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