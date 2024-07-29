namespace Stigma.Protocol.Types.Game.Data.Items;

public sealed class ObjectItemToSellInBid : ObjectItemToSell
{
    public new const ushort ProtocolTypeId = 164;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short UnsoldDelay { get; set; }

    public ObjectItemToSellInBid()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(UnsoldDelay);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        UnsoldDelay = reader.ReadInt16();
    }
}