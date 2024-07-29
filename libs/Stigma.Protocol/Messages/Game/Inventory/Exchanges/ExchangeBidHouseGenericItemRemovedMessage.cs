namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeBidHouseGenericItemRemovedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5948;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int ObjGenericId { get; set; }

    public ExchangeBidHouseGenericItemRemovedMessage()
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