namespace Stigma.Protocol.Types.Game.Interactive.Skill;

public class SkillActionDescriptionCraft : SkillActionDescription
{
    public new const ushort ProtocolTypeId = 100;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public sbyte MaxSlots { get; set; }

    public sbyte Probability { get; set; }

    public SkillActionDescriptionCraft()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt8(MaxSlots);
        writer.WriteInt8(Probability);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        MaxSlots = reader.ReadInt8();
        Probability = reader.ReadInt8();
    }
}