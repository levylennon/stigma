namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Houses;

public sealed class HouseBuyResultMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5735;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int HouseId { get; set; }

    public required bool Bought { get; set; }

    public required int RealPrice { get; set; }

    public HouseBuyResultMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(HouseId);
        writer.WriteBoolean(Bought);
        writer.WriteInt32(RealPrice);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        HouseId = reader.ReadInt32();
        Bought = reader.ReadBoolean();
        RealPrice = reader.ReadInt32();
    }
}