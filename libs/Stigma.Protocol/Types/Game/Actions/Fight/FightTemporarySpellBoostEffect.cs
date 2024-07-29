namespace Stigma.Protocol.Types.Game.Actions.Fight;

public sealed class FightTemporarySpellBoostEffect : FightTemporaryBoostEffect
{
    public new const ushort ProtocolTypeId = 207;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short BoostedSpellId { get; set; }

    public FightTemporarySpellBoostEffect()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(BoostedSpellId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        BoostedSpellId = reader.ReadInt16();
    }
}