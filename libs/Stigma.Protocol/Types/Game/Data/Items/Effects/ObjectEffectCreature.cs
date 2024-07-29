namespace Stigma.Protocol.Types.Game.Data.Items.Effects;

public class ObjectEffectCreature : ObjectEffect
{
    public new const ushort ProtocolTypeId = 71;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short MonsterFamilyId { get; set; }

    public ObjectEffectCreature()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(MonsterFamilyId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        MonsterFamilyId = reader.ReadInt16();
    }
}