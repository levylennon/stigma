namespace Stigma.Protocol.Types.Game.Context.Fight;

public sealed class FightResultTaxCollectorListEntry : FightResultFighterListEntry
{
    public new const ushort ProtocolTypeId = 84;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public byte Level { get; set; }

    public string GuildName { get; set; }

    public int ExperienceForGuild { get; set; }

    public FightResultTaxCollectorListEntry()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUInt8(Level);
        writer.WriteUtf(GuildName);
        writer.WriteInt32(ExperienceForGuild);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Level = reader.ReadUInt8();
        GuildName = reader.ReadUtf();
        ExperienceForGuild = reader.ReadInt32();
    }
}