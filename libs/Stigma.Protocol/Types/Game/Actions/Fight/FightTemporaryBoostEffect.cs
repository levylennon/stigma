namespace Stigma.Protocol.Types.Game.Actions.Fight;

public class FightTemporaryBoostEffect : AbstractFightDispellableEffect
{
    public new const ushort ProtocolTypeId = 209;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short Delta { get; set; }

    public FightTemporaryBoostEffect()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(Delta);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Delta = reader.ReadInt16();
    }
}