using Stigma.Protocol.Types.Game.Data.Items;

namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeShopStockMovementUpdatedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5909;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required ObjectItemToSell ObjectInfo { get; set; }

    public ExchangeShopStockMovementUpdatedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        ObjectInfo.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ObjectInfo = new ObjectItemToSell();
        ObjectInfo.Deserialize(reader);
    }
}