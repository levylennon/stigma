namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeObjectMovePricedMessage : ExchangeObjectMoveMessage
{
    public new const uint ProtocolMessageId = 5514;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Price { get; set; }

    public ExchangeObjectMovePricedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(Price);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Price = reader.ReadInt32();
    }
}