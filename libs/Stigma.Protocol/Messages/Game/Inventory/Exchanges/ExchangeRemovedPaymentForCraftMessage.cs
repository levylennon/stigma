namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeRemovedPaymentForCraftMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6031;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool OnlySuccess { get; set; }

    public required int ObjectUID { get; set; }

    public ExchangeRemovedPaymentForCraftMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(OnlySuccess);
        writer.WriteInt32(ObjectUID);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        OnlySuccess = reader.ReadBoolean();
        ObjectUID = reader.ReadInt32();
    }
}