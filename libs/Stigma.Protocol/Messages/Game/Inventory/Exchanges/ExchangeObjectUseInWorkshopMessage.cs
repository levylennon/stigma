namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeObjectUseInWorkshopMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6004;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int ObjectUID { get; set; }

    public required short Quantity { get; set; }

    public ExchangeObjectUseInWorkshopMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(ObjectUID);
        writer.WriteInt16(Quantity);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ObjectUID = reader.ReadInt32();
        Quantity = reader.ReadInt16();
    }
}