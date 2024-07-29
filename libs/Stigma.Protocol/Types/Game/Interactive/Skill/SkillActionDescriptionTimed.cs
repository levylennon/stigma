namespace Stigma.Protocol.Types.Game.Interactive.Skill;

public class SkillActionDescriptionTimed : SkillActionDescription
{
    public new const ushort ProtocolTypeId = 103;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public byte Time { get; set; }

    public SkillActionDescriptionTimed()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUInt8(Time);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Time = reader.ReadUInt8();
    }
}