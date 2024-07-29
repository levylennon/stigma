namespace Stigma.Protocol.Types.Game.Actions.Fight;

public sealed class FightTemporaryBoostStateEffect : FightTemporaryBoostEffect
{
    public new const ushort ProtocolTypeId = 214;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short StateId { get; set; }

    public FightTemporaryBoostStateEffect()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(StateId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        StateId = reader.ReadInt16();
    }
}