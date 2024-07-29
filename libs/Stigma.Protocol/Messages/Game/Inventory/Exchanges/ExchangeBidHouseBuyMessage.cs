namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeBidHouseBuyMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5804;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Uid { get; set; }

    public required int Qty { get; set; }

    public required int Price { get; set; }

    public ExchangeBidHouseBuyMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Uid);
        writer.WriteInt32(Qty);
        writer.WriteInt32(Price);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Uid = reader.ReadInt32();
        Qty = reader.ReadInt32();
        Price = reader.ReadInt32();
    }
}