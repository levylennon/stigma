namespace Stigma.Protocol.Types.Game.Context.Fight;

public class FightTeamMemberInformations : DofusType
{
    public new const ushort ProtocolTypeId = 44;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int Id { get; set; }

    public FightTeamMemberInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Id);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Id = reader.ReadInt32();
    }
}