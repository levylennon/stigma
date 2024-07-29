using Stigma.Protocol.Types.Game.Look;

namespace Stigma.Protocol.Types.Game.Context.Roleplay;

public sealed class MonsterInGroupInformations : DofusType
{
    public new const ushort ProtocolTypeId = 144;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int CreatureGenericId { get; set; }

    public short Level { get; set; }

    public EntityLook Look { get; set; }

    public MonsterInGroupInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(CreatureGenericId);
        writer.WriteInt16(Level);
        Look.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        CreatureGenericId = reader.ReadInt32();
        Level = reader.ReadInt16();
        Look = new EntityLook();
        Look.Deserialize(reader);
    }
}