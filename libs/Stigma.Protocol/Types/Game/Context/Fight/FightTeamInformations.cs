namespace Stigma.Protocol.Types.Game.Context.Fight;

public sealed class FightTeamInformations : AbstractFightTeamInformations
{
    public new const ushort ProtocolTypeId = 33;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public IEnumerable<FightTeamMemberInformations> TeamMembers { get; set; }

    public FightTeamInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        var teamMembersBefore = writer.Position;
        var teamMembersCount = 0;
        writer.WriteInt16(0);
        foreach (var item in TeamMembers)
        {
            writer.WriteUInt16(item.ProtocolId);
            item.Serialize(writer);
            teamMembersCount++;
        }

        var teamMembersAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, teamMembersBefore);
        writer.WriteInt16((short)teamMembersCount);
        writer.Seek(SeekOrigin.Begin, teamMembersAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        var teamMembersCount = reader.ReadInt16();
        var teamMembers = new FightTeamMemberInformations[teamMembersCount];
        for (var i = 0; i < teamMembersCount; i++)
        {
            var entry = DofusTypeFactory.CreateInstance<FightTeamMemberInformations>(reader.ReadUInt16());
            entry.Deserialize(reader);
            teamMembers[i] = entry;
        }

        TeamMembers = teamMembers;
    }
}