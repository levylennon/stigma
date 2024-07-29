namespace Stigma.Protocol.Types.Game.Actions.Fight;

public sealed class FightTemporaryBoostWeaponDamagesEffect : FightTemporaryBoostEffect
{
    public new const ushort ProtocolTypeId = 211;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short WeaponTypeId { get; set; }

    public FightTemporaryBoostWeaponDamagesEffect()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(WeaponTypeId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        WeaponTypeId = reader.ReadInt16();
    }
}