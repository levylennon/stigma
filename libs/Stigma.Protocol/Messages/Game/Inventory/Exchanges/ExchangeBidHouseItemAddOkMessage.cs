using Stigma.Protocol.Types.Game.Data.Items;

namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeBidHouseItemAddOkMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5945;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required ObjectItemToSellInBid ItemInfo { get; set; }

    public ExchangeBidHouseItemAddOkMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        ItemInfo.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ItemInfo = new ObjectItemToSellInBid();
        ItemInfo.Deserialize(reader);
    }
}