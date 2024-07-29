namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeOnHumanVendorRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5772;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int HumanVendorId { get; set; }

    public required int HumanVendorCell { get; set; }

    public ExchangeOnHumanVendorRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(HumanVendorId);
        writer.WriteInt32(HumanVendorCell);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        HumanVendorId = reader.ReadInt32();
        HumanVendorCell = reader.ReadInt32();
    }
}