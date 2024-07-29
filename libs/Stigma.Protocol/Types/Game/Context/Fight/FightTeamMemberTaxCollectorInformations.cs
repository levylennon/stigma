namespace Stigma.Protocol.Types.Game.Context.Fight;

public sealed class FightTeamMemberTaxCollectorInformations : FightTeamMemberInformations
{
    public new const ushort ProtocolTypeId = 177;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short FirstNameId { get; set; }

    public short LastNameId { get; set; }

    public byte Level { get; set; }

    public FightTeamMemberTaxCollectorInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(FirstNameId);
        writer.WriteInt16(LastNameId);
        writer.WriteUInt8(Level);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        FirstNameId = reader.ReadInt16();
        LastNameId = reader.ReadInt16();
        Level = reader.ReadUInt8();
    }
}