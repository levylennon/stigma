namespace Stigma.Protocol.Types.Game.Context.Fight;

public sealed class FightTeamMemberMonsterInformations : FightTeamMemberInformations
{
    public new const ushort ProtocolTypeId = 6;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int MonsterId { get; set; }

    public sbyte Grade { get; set; }

    public FightTeamMemberMonsterInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(MonsterId);
        writer.WriteInt8(Grade);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        MonsterId = reader.ReadInt32();
        Grade = reader.ReadInt8();
    }
}