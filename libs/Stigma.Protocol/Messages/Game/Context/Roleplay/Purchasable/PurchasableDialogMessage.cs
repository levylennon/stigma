namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Purchasable;

public sealed class PurchasableDialogMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5739;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool BuyOrSell { get; set; }

    public required int PurchasableId { get; set; }

    public required int Price { get; set; }

    public PurchasableDialogMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(BuyOrSell);
        writer.WriteInt32(PurchasableId);
        writer.WriteInt32(Price);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        BuyOrSell = reader.ReadBoolean();
        PurchasableId = reader.ReadInt32();
        Price = reader.ReadInt32();
    }
}