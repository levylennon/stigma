using Stigma.Protocol.Types.Game.Data.Items.Effects;

namespace Stigma.Protocol.Types.Game.Mount;

public sealed class MountClientData : DofusType
{
    public new const ushort ProtocolTypeId = 178;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public bool Sex { get; set; }

    public bool IsRideable { get; set; }

    public bool IsWild { get; set; }

    public bool IsFecondationReady { get; set; }

    public double Id { get; set; }

    public int Model { get; set; }

    public IEnumerable<int> Ancestor { get; set; }

    public IEnumerable<int> Behaviors { get; set; }

    public string Name { get; set; }

    public int OwnerId { get; set; }

    public double Experience { get; set; }

    public double ExperienceForLevel { get; set; }

    public double ExperienceForNextLevel { get; set; }

    public sbyte Level { get; set; }

    public int MaxPods { get; set; }

    public int Stamina { get; set; }

    public int StaminaMax { get; set; }

    public int Maturity { get; set; }

    public int MaturityForAdult { get; set; }

    public int Energy { get; set; }

    public int EnergyMax { get; set; }

    public int Serenity { get; set; }

    public int AggressivityMax { get; set; }

    public int SerenityMax { get; set; }

    public int Love { get; set; }

    public int LoveMax { get; set; }

    public int FecondationTime { get; set; }

    public int BoostLimiter { get; set; }

    public double BoostMax { get; set; }

    public int ReproductionCount { get; set; }

    public int ReproductionCountMax { get; set; }

    public IEnumerable<ObjectEffectInteger> EffectList { get; set; }

    public MountClientData()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, Sex);
        flag = BooleanByteWrapper.SetFlag(flag, 1, IsRideable);
        flag = BooleanByteWrapper.SetFlag(flag, 2, IsWild);
        flag = BooleanByteWrapper.SetFlag(flag, 3, IsFecondationReady);
        writer.WriteUInt8(flag);
        writer.WriteDouble(Id);
        writer.WriteInt32(Model);
        var ancestorBefore = writer.Position;
        var ancestorCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Ancestor)
        {
            writer.WriteInt32(item);
            ancestorCount++;
        }

        var ancestorAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, ancestorBefore);
        writer.WriteInt16((short)ancestorCount);
        writer.Seek(SeekOrigin.Begin, ancestorAfter);
        var behaviorsBefore = writer.Position;
        var behaviorsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Behaviors)
        {
            writer.WriteInt32(item);
            behaviorsCount++;
        }

        var behaviorsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, behaviorsBefore);
        writer.WriteInt16((short)behaviorsCount);
        writer.Seek(SeekOrigin.Begin, behaviorsAfter);
        writer.WriteUtf(Name);
        writer.WriteInt32(OwnerId);
        writer.WriteDouble(Experience);
        writer.WriteDouble(ExperienceForLevel);
        writer.WriteDouble(ExperienceForNextLevel);
        writer.WriteInt8(Level);
        writer.WriteInt32(MaxPods);
        writer.WriteInt32(Stamina);
        writer.WriteInt32(StaminaMax);
        writer.WriteInt32(Maturity);
        writer.WriteInt32(MaturityForAdult);
        writer.WriteInt32(Energy);
        writer.WriteInt32(EnergyMax);
        writer.WriteInt32(Serenity);
        writer.WriteInt32(AggressivityMax);
        writer.WriteInt32(SerenityMax);
        writer.WriteInt32(Love);
        writer.WriteInt32(LoveMax);
        writer.WriteInt32(FecondationTime);
        writer.WriteInt32(BoostLimiter);
        writer.WriteDouble(BoostMax);
        writer.WriteInt32(ReproductionCount);
        writer.WriteInt32(ReproductionCountMax);
        var effectListBefore = writer.Position;
        var effectListCount = 0;
        writer.WriteInt16(0);
        foreach (var item in EffectList)
        {
            item.Serialize(writer);
            effectListCount++;
        }

        var effectListAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, effectListBefore);
        writer.WriteInt16((short)effectListCount);
        writer.Seek(SeekOrigin.Begin, effectListAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var flag = reader.ReadUInt8();
        Sex = BooleanByteWrapper.GetFlag(flag, 0);
        IsRideable = BooleanByteWrapper.GetFlag(flag, 1);
        IsWild = BooleanByteWrapper.GetFlag(flag, 2);
        IsFecondationReady = BooleanByteWrapper.GetFlag(flag, 3);
        Id = reader.ReadDouble();
        Model = reader.ReadInt32();
        var ancestorCount = reader.ReadInt16();
        var ancestor = new int[ancestorCount];
        for (var i = 0; i < ancestorCount; i++) ancestor[i] = reader.ReadInt32();
        Ancestor = ancestor;
        var behaviorsCount = reader.ReadInt16();
        var behaviors = new int[behaviorsCount];
        for (var i = 0; i < behaviorsCount; i++) behaviors[i] = reader.ReadInt32();
        Behaviors = behaviors;
        Name = reader.ReadUtf();
        OwnerId = reader.ReadInt32();
        Experience = reader.ReadDouble();
        ExperienceForLevel = reader.ReadDouble();
        ExperienceForNextLevel = reader.ReadDouble();
        Level = reader.ReadInt8();
        MaxPods = reader.ReadInt32();
        Stamina = reader.ReadInt32();
        StaminaMax = reader.ReadInt32();
        Maturity = reader.ReadInt32();
        MaturityForAdult = reader.ReadInt32();
        Energy = reader.ReadInt32();
        EnergyMax = reader.ReadInt32();
        Serenity = reader.ReadInt32();
        AggressivityMax = reader.ReadInt32();
        SerenityMax = reader.ReadInt32();
        Love = reader.ReadInt32();
        LoveMax = reader.ReadInt32();
        FecondationTime = reader.ReadInt32();
        BoostLimiter = reader.ReadInt32();
        BoostMax = reader.ReadDouble();
        ReproductionCount = reader.ReadInt32();
        ReproductionCountMax = reader.ReadInt32();
        var effectListCount = reader.ReadInt16();
        var effectList = new ObjectEffectInteger[effectListCount];
        for (var i = 0; i < effectListCount; i++)
        {
            var entry = new ObjectEffectInteger();
            entry.Deserialize(reader);
            effectList[i] = entry;
        }

        EffectList = effectList;
    }
}