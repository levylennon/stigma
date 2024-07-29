using Stigma.Protocol.Types.Game.Character.Alignment;

namespace Stigma.Protocol.Types.Game.Character.Characteristic;

public sealed class CharacterCharacteristicsInformations : DofusType
{
    public new const ushort ProtocolTypeId = 8;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public double Experience { get; set; }

    public double ExperienceLevelFloor { get; set; }

    public double ExperienceNextLevelFloor { get; set; }

    public int Kamas { get; set; }

    public int StatsPoints { get; set; }

    public int SpellsPoints { get; set; }

    public ActorExtendedAlignmentInformations AlignmentInfos { get; set; }

    public int LifePoints { get; set; }

    public int MaxLifePoints { get; set; }

    public short EnergyPoints { get; set; }

    public short MaxEnergyPoints { get; set; }

    public short ActionPointsCurrent { get; set; }

    public short MovementPointsCurrent { get; set; }

    public CharacterBaseCharacteristic Initiative { get; set; }

    public CharacterBaseCharacteristic Prospecting { get; set; }

    public CharacterBaseCharacteristic ActionPoints { get; set; }

    public CharacterBaseCharacteristic MovementPoints { get; set; }

    public CharacterBaseCharacteristic Strength { get; set; }

    public CharacterBaseCharacteristic Vitality { get; set; }

    public CharacterBaseCharacteristic Wisdom { get; set; }

    public CharacterBaseCharacteristic Chance { get; set; }

    public CharacterBaseCharacteristic Agility { get; set; }

    public CharacterBaseCharacteristic Intelligence { get; set; }

    public CharacterBaseCharacteristic Range { get; set; }

    public CharacterBaseCharacteristic SummonableCreaturesBoost { get; set; }

    public CharacterBaseCharacteristic Reflect { get; set; }

    public CharacterBaseCharacteristic CriticalHit { get; set; }

    public short CriticalHitWeapon { get; set; }

    public CharacterBaseCharacteristic CriticalMiss { get; set; }

    public CharacterBaseCharacteristic HealBonus { get; set; }

    public CharacterBaseCharacteristic AllDamagesBonus { get; set; }

    public CharacterBaseCharacteristic WeaponDamagesBonusPercent { get; set; }

    public CharacterBaseCharacteristic DamagesBonusPercent { get; set; }

    public CharacterBaseCharacteristic TrapBonus { get; set; }

    public CharacterBaseCharacteristic TrapBonusPercent { get; set; }

    public CharacterBaseCharacteristic PermanentDamagePercent { get; set; }

    public CharacterBaseCharacteristic DodgePALostProbability { get; set; }

    public CharacterBaseCharacteristic DodgePMLostProbability { get; set; }

    public CharacterBaseCharacteristic NeutralElementResistPercent { get; set; }

    public CharacterBaseCharacteristic EarthElementResistPercent { get; set; }

    public CharacterBaseCharacteristic WaterElementResistPercent { get; set; }

    public CharacterBaseCharacteristic AirElementResistPercent { get; set; }

    public CharacterBaseCharacteristic FireElementResistPercent { get; set; }

    public CharacterBaseCharacteristic NeutralElementReduction { get; set; }

    public CharacterBaseCharacteristic EarthElementReduction { get; set; }

    public CharacterBaseCharacteristic WaterElementReduction { get; set; }

    public CharacterBaseCharacteristic AirElementReduction { get; set; }

    public CharacterBaseCharacteristic FireElementReduction { get; set; }

    public CharacterBaseCharacteristic PvpNeutralElementResistPercent { get; set; }

    public CharacterBaseCharacteristic PvpEarthElementResistPercent { get; set; }

    public CharacterBaseCharacteristic PvpWaterElementResistPercent { get; set; }

    public CharacterBaseCharacteristic PvpAirElementResistPercent { get; set; }

    public CharacterBaseCharacteristic PvpFireElementResistPercent { get; set; }

    public CharacterBaseCharacteristic PvpNeutralElementReduction { get; set; }

    public CharacterBaseCharacteristic PvpEarthElementReduction { get; set; }

    public CharacterBaseCharacteristic PvpWaterElementReduction { get; set; }

    public CharacterBaseCharacteristic PvpAirElementReduction { get; set; }

    public CharacterBaseCharacteristic PvpFireElementReduction { get; set; }

    public IEnumerable<CharacterSpellModification> SpellModifications { get; set; }

    public CharacterCharacteristicsInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteDouble(Experience);
        writer.WriteDouble(ExperienceLevelFloor);
        writer.WriteDouble(ExperienceNextLevelFloor);
        writer.WriteInt32(Kamas);
        writer.WriteInt32(StatsPoints);
        writer.WriteInt32(SpellsPoints);
        AlignmentInfos.Serialize(writer);
        writer.WriteInt32(LifePoints);
        writer.WriteInt32(MaxLifePoints);
        writer.WriteInt16(EnergyPoints);
        writer.WriteInt16(MaxEnergyPoints);
        writer.WriteInt16(ActionPointsCurrent);
        writer.WriteInt16(MovementPointsCurrent);
        Initiative.Serialize(writer);
        Prospecting.Serialize(writer);
        ActionPoints.Serialize(writer);
        MovementPoints.Serialize(writer);
        Strength.Serialize(writer);
        Vitality.Serialize(writer);
        Wisdom.Serialize(writer);
        Chance.Serialize(writer);
        Agility.Serialize(writer);
        Intelligence.Serialize(writer);
        Range.Serialize(writer);
        SummonableCreaturesBoost.Serialize(writer);
        Reflect.Serialize(writer);
        CriticalHit.Serialize(writer);
        writer.WriteInt16(CriticalHitWeapon);
        CriticalMiss.Serialize(writer);
        HealBonus.Serialize(writer);
        AllDamagesBonus.Serialize(writer);
        WeaponDamagesBonusPercent.Serialize(writer);
        DamagesBonusPercent.Serialize(writer);
        TrapBonus.Serialize(writer);
        TrapBonusPercent.Serialize(writer);
        PermanentDamagePercent.Serialize(writer);
        DodgePALostProbability.Serialize(writer);
        DodgePMLostProbability.Serialize(writer);
        NeutralElementResistPercent.Serialize(writer);
        EarthElementResistPercent.Serialize(writer);
        WaterElementResistPercent.Serialize(writer);
        AirElementResistPercent.Serialize(writer);
        FireElementResistPercent.Serialize(writer);
        NeutralElementReduction.Serialize(writer);
        EarthElementReduction.Serialize(writer);
        WaterElementReduction.Serialize(writer);
        AirElementReduction.Serialize(writer);
        FireElementReduction.Serialize(writer);
        PvpNeutralElementResistPercent.Serialize(writer);
        PvpEarthElementResistPercent.Serialize(writer);
        PvpWaterElementResistPercent.Serialize(writer);
        PvpAirElementResistPercent.Serialize(writer);
        PvpFireElementResistPercent.Serialize(writer);
        PvpNeutralElementReduction.Serialize(writer);
        PvpEarthElementReduction.Serialize(writer);
        PvpWaterElementReduction.Serialize(writer);
        PvpAirElementReduction.Serialize(writer);
        PvpFireElementReduction.Serialize(writer);
        var spellModificationsBefore = writer.Position;
        var spellModificationsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in SpellModifications)
        {
            item.Serialize(writer);
            spellModificationsCount++;
        }

        var spellModificationsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, spellModificationsBefore);
        writer.WriteInt16((short)spellModificationsCount);
        writer.Seek(SeekOrigin.Begin, spellModificationsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Experience = reader.ReadDouble();
        ExperienceLevelFloor = reader.ReadDouble();
        ExperienceNextLevelFloor = reader.ReadDouble();
        Kamas = reader.ReadInt32();
        StatsPoints = reader.ReadInt32();
        SpellsPoints = reader.ReadInt32();
        AlignmentInfos = new ActorExtendedAlignmentInformations();
        AlignmentInfos.Deserialize(reader);
        LifePoints = reader.ReadInt32();
        MaxLifePoints = reader.ReadInt32();
        EnergyPoints = reader.ReadInt16();
        MaxEnergyPoints = reader.ReadInt16();
        ActionPointsCurrent = reader.ReadInt16();
        MovementPointsCurrent = reader.ReadInt16();
        Initiative = new CharacterBaseCharacteristic();
        Initiative.Deserialize(reader);
        Prospecting = new CharacterBaseCharacteristic();
        Prospecting.Deserialize(reader);
        ActionPoints = new CharacterBaseCharacteristic();
        ActionPoints.Deserialize(reader);
        MovementPoints = new CharacterBaseCharacteristic();
        MovementPoints.Deserialize(reader);
        Strength = new CharacterBaseCharacteristic();
        Strength.Deserialize(reader);
        Vitality = new CharacterBaseCharacteristic();
        Vitality.Deserialize(reader);
        Wisdom = new CharacterBaseCharacteristic();
        Wisdom.Deserialize(reader);
        Chance = new CharacterBaseCharacteristic();
        Chance.Deserialize(reader);
        Agility = new CharacterBaseCharacteristic();
        Agility.Deserialize(reader);
        Intelligence = new CharacterBaseCharacteristic();
        Intelligence.Deserialize(reader);
        Range = new CharacterBaseCharacteristic();
        Range.Deserialize(reader);
        SummonableCreaturesBoost = new CharacterBaseCharacteristic();
        SummonableCreaturesBoost.Deserialize(reader);
        Reflect = new CharacterBaseCharacteristic();
        Reflect.Deserialize(reader);
        CriticalHit = new CharacterBaseCharacteristic();
        CriticalHit.Deserialize(reader);
        CriticalHitWeapon = reader.ReadInt16();
        CriticalMiss = new CharacterBaseCharacteristic();
        CriticalMiss.Deserialize(reader);
        HealBonus = new CharacterBaseCharacteristic();
        HealBonus.Deserialize(reader);
        AllDamagesBonus = new CharacterBaseCharacteristic();
        AllDamagesBonus.Deserialize(reader);
        WeaponDamagesBonusPercent = new CharacterBaseCharacteristic();
        WeaponDamagesBonusPercent.Deserialize(reader);
        DamagesBonusPercent = new CharacterBaseCharacteristic();
        DamagesBonusPercent.Deserialize(reader);
        TrapBonus = new CharacterBaseCharacteristic();
        TrapBonus.Deserialize(reader);
        TrapBonusPercent = new CharacterBaseCharacteristic();
        TrapBonusPercent.Deserialize(reader);
        PermanentDamagePercent = new CharacterBaseCharacteristic();
        PermanentDamagePercent.Deserialize(reader);
        DodgePALostProbability = new CharacterBaseCharacteristic();
        DodgePALostProbability.Deserialize(reader);
        DodgePMLostProbability = new CharacterBaseCharacteristic();
        DodgePMLostProbability.Deserialize(reader);
        NeutralElementResistPercent = new CharacterBaseCharacteristic();
        NeutralElementResistPercent.Deserialize(reader);
        EarthElementResistPercent = new CharacterBaseCharacteristic();
        EarthElementResistPercent.Deserialize(reader);
        WaterElementResistPercent = new CharacterBaseCharacteristic();
        WaterElementResistPercent.Deserialize(reader);
        AirElementResistPercent = new CharacterBaseCharacteristic();
        AirElementResistPercent.Deserialize(reader);
        FireElementResistPercent = new CharacterBaseCharacteristic();
        FireElementResistPercent.Deserialize(reader);
        NeutralElementReduction = new CharacterBaseCharacteristic();
        NeutralElementReduction.Deserialize(reader);
        EarthElementReduction = new CharacterBaseCharacteristic();
        EarthElementReduction.Deserialize(reader);
        WaterElementReduction = new CharacterBaseCharacteristic();
        WaterElementReduction.Deserialize(reader);
        AirElementReduction = new CharacterBaseCharacteristic();
        AirElementReduction.Deserialize(reader);
        FireElementReduction = new CharacterBaseCharacteristic();
        FireElementReduction.Deserialize(reader);
        PvpNeutralElementResistPercent = new CharacterBaseCharacteristic();
        PvpNeutralElementResistPercent.Deserialize(reader);
        PvpEarthElementResistPercent = new CharacterBaseCharacteristic();
        PvpEarthElementResistPercent.Deserialize(reader);
        PvpWaterElementResistPercent = new CharacterBaseCharacteristic();
        PvpWaterElementResistPercent.Deserialize(reader);
        PvpAirElementResistPercent = new CharacterBaseCharacteristic();
        PvpAirElementResistPercent.Deserialize(reader);
        PvpFireElementResistPercent = new CharacterBaseCharacteristic();
        PvpFireElementResistPercent.Deserialize(reader);
        PvpNeutralElementReduction = new CharacterBaseCharacteristic();
        PvpNeutralElementReduction.Deserialize(reader);
        PvpEarthElementReduction = new CharacterBaseCharacteristic();
        PvpEarthElementReduction.Deserialize(reader);
        PvpWaterElementReduction = new CharacterBaseCharacteristic();
        PvpWaterElementReduction.Deserialize(reader);
        PvpAirElementReduction = new CharacterBaseCharacteristic();
        PvpAirElementReduction.Deserialize(reader);
        PvpFireElementReduction = new CharacterBaseCharacteristic();
        PvpFireElementReduction.Deserialize(reader);
        var spellModificationsCount = reader.ReadInt16();
        var spellModifications = new CharacterSpellModification[spellModificationsCount];
        for (var i = 0; i < spellModificationsCount; i++)
        {
            var entry = new CharacterSpellModification();
            entry.Deserialize(reader);
            spellModifications[i] = entry;
        }

        SpellModifications = spellModifications;
    }
}