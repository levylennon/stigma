namespace Stigma.Protocol.Types.Game.Interactive.Skill;

public sealed class SkillActionDescriptionCraftExtended : SkillActionDescriptionCraft
{
    public new const ushort ProtocolTypeId = 104;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public sbyte ThresholdSlots { get; set; }

    public sbyte OptimumProbability { get; set; }

    public SkillActionDescriptionCraftExtended()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt8(ThresholdSlots);
        writer.WriteInt8(OptimumProbability);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        ThresholdSlots = reader.ReadInt8();
        OptimumProbability = reader.ReadInt8();
    }
}