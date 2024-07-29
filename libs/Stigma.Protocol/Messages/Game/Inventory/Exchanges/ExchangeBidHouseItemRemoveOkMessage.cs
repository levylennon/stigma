namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeBidHouseItemRemoveOkMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5946;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int SellerId { get; set; }

    public ExchangeBidHouseItemRemoveOkMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(SellerId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        SellerId = reader.ReadInt32();
    }
}