namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Houses;

public sealed class HouseSoldMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5737;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int HouseId { get; set; }

    public required int RealPrice { get; set; }

    public required string BuyerName { get; set; }

    public HouseSoldMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(HouseId);
        writer.WriteInt32(RealPrice);
        writer.WriteUtf(BuyerName);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        HouseId = reader.ReadInt32();
        RealPrice = reader.ReadInt32();
        BuyerName = reader.ReadUtf();
    }
}