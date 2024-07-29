using Stigma.Protocol.Types.Game.Data.Items;

namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeModifiedPaymentForCraftMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5832;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool OnlySuccess { get; set; }

    public required ObjectItemNotInContainer Object { get; set; }

    public ExchangeModifiedPaymentForCraftMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(OnlySuccess);
        Object.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        OnlySuccess = reader.ReadBoolean();
        Object = new ObjectItemNotInContainer();
        Object.Deserialize(reader);
    }
}