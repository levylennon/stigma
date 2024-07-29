using Stigma.Protocol.Types.Game.Interactive.Skill;

namespace Stigma.Protocol.Types.Game.Context.Roleplay.Job;

public sealed class JobDescription : DofusType
{
    public new const ushort ProtocolTypeId = 101;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public sbyte JobId { get; set; }

    public IEnumerable<SkillActionDescription> Skills { get; set; }

    public JobDescription()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(JobId);
        var skillsBefore = writer.Position;
        var skillsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Skills)
        {
            writer.WriteUInt16(item.ProtocolId);
            item.Serialize(writer);
            skillsCount++;
        }

        var skillsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, skillsBefore);
        writer.WriteInt16((short)skillsCount);
        writer.Seek(SeekOrigin.Begin, skillsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        JobId = reader.ReadInt8();
        var skillsCount = reader.ReadInt16();
        var skills = new SkillActionDescription[skillsCount];
        for (var i = 0; i < skillsCount; i++)
        {
            var entry = DofusTypeFactory.CreateInstance<SkillActionDescription>(reader.ReadUInt16());
            entry.Deserialize(reader);
            skills[i] = entry;
        }

        Skills = skills;
    }
}