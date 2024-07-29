namespace Stigma.Protocol.Types.Game.Context.Fight;

public sealed class FightExternalInformations : DofusType
{
    public new const ushort ProtocolTypeId = 117;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int FightId { get; set; }

    public int FightStart { get; set; }

    public bool FightSpectatorLocked { get; set; }

    public IEnumerable<FightTeamLightInformations> FightTeams { get; set; }

    public FightExternalInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(FightId);
        writer.WriteInt32(FightStart);
        writer.WriteBoolean(FightSpectatorLocked);
        var fightTeamsBefore = writer.Position;
        var fightTeamsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in FightTeams)
        {
            item.Serialize(writer);
            fightTeamsCount++;
        }

        var fightTeamsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, fightTeamsBefore);
        writer.WriteInt16((short)fightTeamsCount);
        writer.Seek(SeekOrigin.Begin, fightTeamsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FightId = reader.ReadInt32();
        FightStart = reader.ReadInt32();
        FightSpectatorLocked = reader.ReadBoolean();
        var fightTeamsCount = reader.ReadInt16();
        var fightTeams = new FightTeamLightInformations[fightTeamsCount];
        for (var i = 0; i < fightTeamsCount; i++)
        {
            var entry = new FightTeamLightInformations();
            entry.Deserialize(reader);
            fightTeams[i] = entry;
        }

        FightTeams = fightTeams;
    }
}