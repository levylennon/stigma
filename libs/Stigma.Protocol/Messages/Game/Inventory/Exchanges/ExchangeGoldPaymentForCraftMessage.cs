namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeGoldPaymentForCraftMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5833;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool OnlySuccess { get; set; }

    public required int GoldSum { get; set; }

    public ExchangeGoldPaymentForCraftMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(OnlySuccess);
        writer.WriteInt32(GoldSum);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        OnlySuccess = reader.ReadBoolean();
        GoldSum = reader.ReadInt32();
    }
}