namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeBidHouseTypeMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5803;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Type { get; set; }

    public ExchangeBidHouseTypeMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Type);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Type = reader.ReadInt32();
    }
}