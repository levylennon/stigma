namespace Stigma.Protocol.Types.Game.Data.Items;

public sealed class GoldItem : Item
{
    public new const ushort ProtocolTypeId = 123;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int Sum { get; set; }

    public GoldItem()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(Sum);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Sum = reader.ReadInt32();
    }
}