namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeBidPriceMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5755;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int GenericId { get; set; }

    public required int AveragePrice { get; set; }

    public ExchangeBidPriceMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(GenericId);
        writer.WriteInt32(AveragePrice);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        GenericId = reader.ReadInt32();
        AveragePrice = reader.ReadInt32();
    }
}