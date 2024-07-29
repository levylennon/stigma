namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeBidHouseListMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5807;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Id { get; set; }

    public ExchangeBidHouseListMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Id);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Id = reader.ReadInt32();
    }
}