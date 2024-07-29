namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeBidHouseSearchMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5806;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Type { get; set; }

    public required int GenId { get; set; }

    public ExchangeBidHouseSearchMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Type);
        writer.WriteInt32(GenId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Type = reader.ReadInt32();
        GenId = reader.ReadInt32();
    }
}