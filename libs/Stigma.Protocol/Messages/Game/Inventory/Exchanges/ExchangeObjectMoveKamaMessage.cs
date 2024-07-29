namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeObjectMoveKamaMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5520;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Quantity { get; set; }

    public ExchangeObjectMoveKamaMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Quantity);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Quantity = reader.ReadInt32();
    }
}