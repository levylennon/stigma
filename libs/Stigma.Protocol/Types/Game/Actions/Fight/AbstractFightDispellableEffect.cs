namespace Stigma.Protocol.Types.Game.Actions.Fight;

public class AbstractFightDispellableEffect : DofusType
{
    public new const ushort ProtocolTypeId = 206;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int Uid { get; set; }

    public int TargetId { get; set; }

    public short TurnDuration { get; set; }

    public sbyte Dispelable { get; set; }

    public short SpellId { get; set; }

    public AbstractFightDispellableEffect()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Uid);
        writer.WriteInt32(TargetId);
        writer.WriteInt16(TurnDuration);
        writer.WriteInt8(Dispelable);
        writer.WriteInt16(SpellId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Uid = reader.ReadInt32();
        TargetId = reader.ReadInt32();
        TurnDuration = reader.ReadInt16();
        Dispelable = reader.ReadInt8();
        SpellId = reader.ReadInt16();
    }
}