namespace Stigma.Protocol.Types.Game.Context.Fight;

public sealed class FightTeamLightInformations : AbstractFightTeamInformations
{
    public new const ushort ProtocolTypeId = 115;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public sbyte TeamMembersCount { get; set; }

    public FightTeamLightInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt8(TeamMembersCount);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        TeamMembersCount = reader.ReadInt8();
    }
}