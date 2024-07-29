namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Paddock;

public sealed class PaddockSellBuyDialogMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6018;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Bsell { get; set; }

    public required int OwnerId { get; set; }

    public required int Price { get; set; }

    public PaddockSellBuyDialogMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(Bsell);
        writer.WriteInt32(OwnerId);
        writer.WriteInt32(Price);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Bsell = reader.ReadBoolean();
        OwnerId = reader.ReadInt32();
        Price = reader.ReadInt32();
    }
}