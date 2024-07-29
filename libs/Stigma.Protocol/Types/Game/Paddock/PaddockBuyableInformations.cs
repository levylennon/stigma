namespace Stigma.Protocol.Types.Game.Paddock;

public class PaddockBuyableInformations : PaddockInformations
{
    public new const ushort ProtocolTypeId = 130;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int Price { get; set; }

    public PaddockBuyableInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(Price);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Price = reader.ReadInt32();
    }
}