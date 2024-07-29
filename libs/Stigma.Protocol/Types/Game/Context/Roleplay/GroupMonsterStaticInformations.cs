namespace Stigma.Protocol.Types.Game.Context.Roleplay;

public sealed class GroupMonsterStaticInformations : DofusType
{
    public new const ushort ProtocolTypeId = 140;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int MainCreatureGenericId { get; set; }

    public short MainCreaturelevel { get; set; }

    public IEnumerable<MonsterInGroupInformations> Underlings { get; set; }

    public GroupMonsterStaticInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(MainCreatureGenericId);
        writer.WriteInt16(MainCreaturelevel);
        var underlingsBefore = writer.Position;
        var underlingsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Underlings)
        {
            item.Serialize(writer);
            underlingsCount++;
        }

        var underlingsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, underlingsBefore);
        writer.WriteInt16((short)underlingsCount);
        writer.Seek(SeekOrigin.Begin, underlingsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        MainCreatureGenericId = reader.ReadInt32();
        MainCreaturelevel = reader.ReadInt16();
        var underlingsCount = reader.ReadInt16();
        var underlings = new MonsterInGroupInformations[underlingsCount];
        for (var i = 0; i < underlingsCount; i++)
        {
            var entry = new MonsterInGroupInformations();
            entry.Deserialize(reader);
            underlings[i] = entry;
        }

        Underlings = underlings;
    }
}