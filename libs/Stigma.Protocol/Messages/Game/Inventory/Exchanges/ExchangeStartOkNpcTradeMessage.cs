namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeStartOkNpcTradeMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5785;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int NpcId { get; set; }

    public ExchangeStartOkNpcTradeMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(NpcId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        NpcId = reader.ReadInt32();
    }
}