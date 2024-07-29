namespace Stigma.Protocol.Types.Game.Interactive;

public sealed class InteractiveElement : DofusType
{
    public new const ushort ProtocolTypeId = 80;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int ElementId { get; set; }

    public IEnumerable<short> EnabledSkillIds { get; set; }

    public IEnumerable<short> DisabledSkillIds { get; set; }

    public InteractiveElement()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(ElementId);
        var enabledSkillIdsBefore = writer.Position;
        var enabledSkillIdsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in EnabledSkillIds)
        {
            writer.WriteInt16(item);
            enabledSkillIdsCount++;
        }

        var enabledSkillIdsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, enabledSkillIdsBefore);
        writer.WriteInt16((short)enabledSkillIdsCount);
        writer.Seek(SeekOrigin.Begin, enabledSkillIdsAfter);
        var disabledSkillIdsBefore = writer.Position;
        var disabledSkillIdsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in DisabledSkillIds)
        {
            writer.WriteInt16(item);
            disabledSkillIdsCount++;
        }

        var disabledSkillIdsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, disabledSkillIdsBefore);
        writer.WriteInt16((short)disabledSkillIdsCount);
        writer.Seek(SeekOrigin.Begin, disabledSkillIdsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ElementId = reader.ReadInt32();
        var enabledSkillIdsCount = reader.ReadInt16();
        var enabledSkillIds = new short[enabledSkillIdsCount];
        for (var i = 0; i < enabledSkillIdsCount; i++) enabledSkillIds[i] = reader.ReadInt16();
        EnabledSkillIds = enabledSkillIds;
        var disabledSkillIdsCount = reader.ReadInt16();
        var disabledSkillIds = new short[disabledSkillIdsCount];
        for (var i = 0; i < disabledSkillIdsCount; i++) disabledSkillIds[i] = reader.ReadInt16();
        DisabledSkillIds = disabledSkillIds;
    }
}