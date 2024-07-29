namespace Stigma.Protocol.Types.Game.Interactive.Skill;

public sealed class SkillActionDescriptionCollect : SkillActionDescriptionTimed
{
    public new const ushort ProtocolTypeId = 99;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short Min { get; set; }

    public short Max { get; set; }

    public SkillActionDescriptionCollect()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(Min);
        writer.WriteInt16(Max);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Min = reader.ReadInt16();
        Max = reader.ReadInt16();
    }
}