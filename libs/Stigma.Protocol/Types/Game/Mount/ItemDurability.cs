namespace Stigma.Protocol.Types.Game.Mount;

public sealed class ItemDurability : DofusType
{
    public new const ushort ProtocolTypeId = 168;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short Durability { get; set; }

    public short DurabilityMax { get; set; }

    public ItemDurability()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(Durability);
        writer.WriteInt16(DurabilityMax);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Durability = reader.ReadInt16();
        DurabilityMax = reader.ReadInt16();
    }
}