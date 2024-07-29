namespace Stigma.Protocol.Types.Game.Context.Fight;

public sealed class FightResultPvpData : FightResultAdditionalData
{
    public new const ushort ProtocolTypeId = 190;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public byte Grade { get; set; }

    public ushort MinHonorForGrade { get; set; }

    public ushort MaxHonorForGrade { get; set; }

    public ushort Honor { get; set; }

    public short HonorDelta { get; set; }

    public ushort Dishonor { get; set; }

    public short DishonorDelta { get; set; }

    public FightResultPvpData()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUInt8(Grade);
        writer.WriteUInt16(MinHonorForGrade);
        writer.WriteUInt16(MaxHonorForGrade);
        writer.WriteUInt16(Honor);
        writer.WriteInt16(HonorDelta);
        writer.WriteUInt16(Dishonor);
        writer.WriteInt16(DishonorDelta);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Grade = reader.ReadUInt8();
        MinHonorForGrade = reader.ReadUInt16();
        MaxHonorForGrade = reader.ReadUInt16();
        Honor = reader.ReadUInt16();
        HonorDelta = reader.ReadInt16();
        Dishonor = reader.ReadUInt16();
        DishonorDelta = reader.ReadInt16();
    }
}