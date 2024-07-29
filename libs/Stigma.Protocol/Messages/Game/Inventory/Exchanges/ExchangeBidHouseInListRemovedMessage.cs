namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeBidHouseInListRemovedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5950;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int ItemUID { get; set; }

    public ExchangeBidHouseInListRemovedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(ItemUID);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ItemUID = reader.ReadInt32();
    }
}