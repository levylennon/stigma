namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeBuyMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5774;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int ObjectToBuyId { get; set; }

    public required int Quantity { get; set; }

    public ExchangeBuyMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(ObjectToBuyId);
        writer.WriteInt32(Quantity);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ObjectToBuyId = reader.ReadInt32();
        Quantity = reader.ReadInt32();
    }
}