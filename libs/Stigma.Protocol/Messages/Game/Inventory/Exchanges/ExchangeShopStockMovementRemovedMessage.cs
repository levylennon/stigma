namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeShopStockMovementRemovedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5907;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int ObjectId { get; set; }

    public ExchangeShopStockMovementRemovedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(ObjectId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ObjectId = reader.ReadInt32();
    }
}