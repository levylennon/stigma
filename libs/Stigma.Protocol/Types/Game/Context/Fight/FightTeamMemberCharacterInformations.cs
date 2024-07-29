namespace Stigma.Protocol.Types.Game.Context.Fight;

public sealed class FightTeamMemberCharacterInformations : FightTeamMemberInformations
{
    public new const ushort ProtocolTypeId = 13;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public string Name { get; set; }

    public short Level { get; set; }

    public FightTeamMemberCharacterInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUtf(Name);
        writer.WriteInt16(Level);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Name = reader.ReadUtf();
        Level = reader.ReadInt16();
    }
}