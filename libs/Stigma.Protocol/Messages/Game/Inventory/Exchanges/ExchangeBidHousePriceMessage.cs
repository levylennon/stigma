namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeBidHousePriceMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5805;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int GenId { get; set; }

    public ExchangeBidHousePriceMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(GenId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        GenId = reader.ReadInt32();
    }
}