namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeSellMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5778;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int ObjectToSellId { get; set; }

    public required int Quantity { get; set; }

    public ExchangeSellMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(ObjectToSellId);
        writer.WriteInt32(Quantity);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ObjectToSellId = reader.ReadInt32();
        Quantity = reader.ReadInt32();
    }
}