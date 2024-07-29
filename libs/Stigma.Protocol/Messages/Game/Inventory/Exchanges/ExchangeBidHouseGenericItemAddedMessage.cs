namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeBidHouseGenericItemAddedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5947;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int ObjGenericId { get; set; }

    public ExchangeBidHouseGenericItemAddedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(ObjGenericId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ObjGenericId = reader.ReadInt32();
    }
}