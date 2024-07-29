namespace Stigma.Protocol.Types.Game.Interactive.Skill;

public class SkillActionDescription : DofusType
{
    public new const ushort ProtocolTypeId = 102;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short SkillId { get; set; }

    public SkillActionDescription()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(SkillId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        SkillId = reader.ReadInt16();
    }
}