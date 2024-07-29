namespace Stigma.Protocol.Types.Game.Context.Fight;

public sealed class FightResultExperienceData : FightResultAdditionalData
{
    public new const ushort ProtocolTypeId = 192;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public bool ShowExperience { get; set; }

    public bool ShowExperienceLevelFloor { get; set; }

    public bool ShowExperienceNextLevelFloor { get; set; }

    public bool ShowExperienceFightDelta { get; set; }

    public bool ShowExperienceForGuild { get; set; }

    public bool ShowExperienceForMount { get; set; }

    public double Experience { get; set; }

    public double ExperienceLevelFloor { get; set; }

    public double ExperienceNextLevelFloor { get; set; }

    public int ExperienceFightDelta { get; set; }

    public int ExperienceForGuild { get; set; }

    public int ExperienceForMount { get; set; }

    public FightResultExperienceData()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, ShowExperience);
        flag = BooleanByteWrapper.SetFlag(flag, 1, ShowExperienceLevelFloor);
        flag = BooleanByteWrapper.SetFlag(flag, 2, ShowExperienceNextLevelFloor);
        flag = BooleanByteWrapper.SetFlag(flag, 3, ShowExperienceFightDelta);
        flag = BooleanByteWrapper.SetFlag(flag, 4, ShowExperienceForGuild);
        flag = BooleanByteWrapper.SetFlag(flag, 5, ShowExperienceForMount);
        writer.WriteUInt8(flag);
        writer.WriteDouble(Experience);
        writer.WriteDouble(ExperienceLevelFloor);
        writer.WriteDouble(ExperienceNextLevelFloor);
        writer.WriteInt32(ExperienceFightDelta);
        writer.WriteInt32(ExperienceForGuild);
        writer.WriteInt32(ExperienceForMount);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        var flag = reader.ReadUInt8();
        ShowExperience = BooleanByteWrapper.GetFlag(flag, 0);
        ShowExperienceLevelFloor = BooleanByteWrapper.GetFlag(flag, 1);
        ShowExperienceNextLevelFloor = BooleanByteWrapper.GetFlag(flag, 2);
        ShowExperienceFightDelta = BooleanByteWrapper.GetFlag(flag, 3);
        ShowExperienceForGuild = BooleanByteWrapper.GetFlag(flag, 4);
        ShowExperienceForMount = BooleanByteWrapper.GetFlag(flag, 5);
        Experience = reader.ReadDouble();
        ExperienceLevelFloor = reader.ReadDouble();
        ExperienceNextLevelFloor = reader.ReadDouble();
        ExperienceFightDelta = reader.ReadInt32();
        ExperienceForGuild = reader.ReadInt32();
        ExperienceForMount = reader.ReadInt32();
    }
}