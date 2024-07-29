namespace Stigma.Protocol.Types.Game.House;

public sealed class HouseInformationsForGuild : DofusType
{
    public new const ushort ProtocolTypeId = 170;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int HouseId { get; set; }

    public string OwnerName { get; set; }

    public short WorldX { get; set; }

    public short WorldY { get; set; }

    public IEnumerable<int> SkillListIds { get; set; }

    public uint GuildshareParams { get; set; }

    public HouseInformationsForGuild()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(HouseId);
        writer.WriteUtf(OwnerName);
        writer.WriteInt16(WorldX);
        writer.WriteInt16(WorldY);
        var skillListIdsBefore = writer.Position;
        var skillListIdsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in SkillListIds)
        {
            writer.WriteInt32(item);
            skillListIdsCount++;
        }

        var skillListIdsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, skillListIdsBefore);
        writer.WriteInt16((short)skillListIdsCount);
        writer.Seek(SeekOrigin.Begin, skillListIdsAfter);
        writer.WriteUInt32(GuildshareParams);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        HouseId = reader.ReadInt32();
        OwnerName = reader.ReadUtf();
        WorldX = reader.ReadInt16();
        WorldY = reader.ReadInt16();
        var skillListIdsCount = reader.ReadInt16();
        var skillListIds = new int[skillListIdsCount];
        for (var i = 0; i < skillListIdsCount; i++) skillListIds[i] = reader.ReadInt32();
        SkillListIds = skillListIds;
        GuildshareParams = reader.ReadUInt32();
    }
}