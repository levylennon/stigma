using Stigma.Protocol.Types.Game.Data.Items;

namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeStartedBidBuyerMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5904;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required SellerBuyerDescriptor BuyerDescriptor { get; set; }

    public ExchangeStartedBidBuyerMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        BuyerDescriptor.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        BuyerDescriptor = new SellerBuyerDescriptor();
        BuyerDescriptor.Deserialize(reader);
    }
}