namespace Stigma.Protocol.Types.Game.Data.Items;

public sealed class ObjectItemToSellInNpcShop : ObjectItemMinimalInformation
{
    public new const ushort ProtocolTypeId = 352;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int ObjectPrice { get; set; }

    public string BuyCriterion { get; set; }

    public ObjectItemToSellInNpcShop()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(ObjectPrice);
        writer.WriteUtf(BuyCriterion);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        ObjectPrice = reader.ReadInt32();
        BuyCriterion = reader.ReadUtf();
    }
}