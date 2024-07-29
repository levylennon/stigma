namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public class ExchangeCraftResultWithObjectIdMessage : ExchangeCraftResultMessage
{
    public new const uint ProtocolMessageId = 6000;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int ObjectGenericId { get; set; }

    public ExchangeCraftResultWithObjectIdMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(ObjectGenericId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        ObjectGenericId = reader.ReadInt32();
    }
}