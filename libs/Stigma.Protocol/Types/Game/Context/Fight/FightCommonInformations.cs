namespace Stigma.Protocol.Types.Game.Context.Fight;

public sealed class FightCommonInformations : DofusType
{
    public new const ushort ProtocolTypeId = 43;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int FightId { get; set; }

    public sbyte FightType { get; set; }

    public IEnumerable<FightTeamInformations> FightTeams { get; set; }

    public IEnumerable<short> FightTeamsPositions { get; set; }

    public IEnumerable<FightOptionsInformations> FightTeamsOptions { get; set; }

    public FightCommonInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(FightId);
        writer.WriteInt8(FightType);
        var fightTeamsBefore = writer.Position;
        var fightTeamsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in FightTeams)
        {
            writer.WriteUInt16(item.ProtocolId);
            item.Serialize(writer);
            fightTeamsCount++;
        }

        var fightTeamsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, fightTeamsBefore);
        writer.WriteInt16((short)fightTeamsCount);
        writer.Seek(SeekOrigin.Begin, fightTeamsAfter);
        var fightTeamsPositionsBefore = writer.Position;
        var fightTeamsPositionsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in FightTeamsPositions)
        {
            writer.WriteInt16(item);
            fightTeamsPositionsCount++;
        }

        var fightTeamsPositionsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, fightTeamsPositionsBefore);
        writer.WriteInt16((short)fightTeamsPositionsCount);
        writer.Seek(SeekOrigin.Begin, fightTeamsPositionsAfter);
        var fightTeamsOptionsBefore = writer.Position;
        var fightTeamsOptionsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in FightTeamsOptions)
        {
            item.Serialize(writer);
            fightTeamsOptionsCount++;
        }

        var fightTeamsOptionsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, fightTeamsOptionsBefore);
        writer.WriteInt16((short)fightTeamsOptionsCount);
        writer.Seek(SeekOrigin.Begin, fightTeamsOptionsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FightId = reader.ReadInt32();
        FightType = reader.ReadInt8();
        var fightTeamsCount = reader.ReadInt16();
        var fightTeams = new FightTeamInformations[fightTeamsCount];
        for (var i = 0; i < fightTeamsCount; i++)
        {
            var entry = DofusTypeFactory.CreateInstance<FightTeamInformations>(reader.ReadUInt16());
            entry.Deserialize(reader);
            fightTeams[i] = entry;
        }

        FightTeams = fightTeams;
        var fightTeamsPositionsCount = reader.ReadInt16();
        var fightTeamsPositions = new short[fightTeamsPositionsCount];
        for (var i = 0; i < fightTeamsPositionsCount; i++) fightTeamsPositions[i] = reader.ReadInt16();
        FightTeamsPositions = fightTeamsPositions;
        var fightTeamsOptionsCount = reader.ReadInt16();
        var fightTeamsOptions = new FightOptionsInformations[fightTeamsOptionsCount];
        for (var i = 0; i < fightTeamsOptionsCount; i++)
        {
            var entry = new FightOptionsInformations();
            entry.Deserialize(reader);
            fightTeamsOptions[i] = entry;
        }

        FightTeamsOptions = fightTeamsOptions;
    }
}