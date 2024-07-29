namespace Stigma.Protocol.Types.Game.Data.Items;

public sealed class SpellItem : Item
{
    public new const ushort ProtocolTypeId = 49;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public byte Position { get; set; }

    public int SpellId { get; set; }

    public sbyte SpellLevel { get; set; }

    public SpellItem()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUInt8(Position);
        writer.WriteInt32(SpellId);
        writer.WriteInt8(SpellLevel);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Position = reader.ReadUInt8();
        SpellId = reader.ReadInt32();
        SpellLevel = reader.ReadInt8();
    }
}