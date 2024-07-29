namespace Stigma.Protocol.Types.Game.Actions.Fight;

public sealed class FightTriggeredEffect : AbstractFightDispellableEffect
{
    public new const ushort ProtocolTypeId = 210;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public sbyte Trigger { get; set; }

    public int Param1 { get; set; }

    public int Param2 { get; set; }

    public int Param3 { get; set; }

    public FightTriggeredEffect()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt8(Trigger);
        writer.WriteInt32(Param1);
        writer.WriteInt32(Param2);
        writer.WriteInt32(Param3);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Trigger = reader.ReadInt8();
        Param1 = reader.ReadInt32();
        Param2 = reader.ReadInt32();
        Param3 = reader.ReadInt32();
    }
}