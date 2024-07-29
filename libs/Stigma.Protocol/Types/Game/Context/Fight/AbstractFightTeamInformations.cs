namespace Stigma.Protocol.Types.Game.Context.Fight;

public class AbstractFightTeamInformations : DofusType
{
    public new const ushort ProtocolTypeId = 116;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public sbyte TeamId { get; set; }

    public int LeaderId { get; set; }

    public sbyte TeamSide { get; set; }

    public AbstractFightTeamInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(TeamId);
        writer.WriteInt32(LeaderId);
        writer.WriteInt8(TeamSide);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        TeamId = reader.ReadInt8();
        LeaderId = reader.ReadInt32();
        TeamSide = reader.ReadInt8();
    }
}