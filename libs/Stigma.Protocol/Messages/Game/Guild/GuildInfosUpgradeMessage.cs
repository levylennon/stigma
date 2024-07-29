namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildInfosUpgradeMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5636;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte MaxTaxCollectorsCount { get; set; }

    public required sbyte TaxCollectorsCount { get; set; }

    public required short TaxCollectorLifePoints { get; set; }

    public required short TaxCollectorDamagesBonuses { get; set; }

    public required short TaxCollectorPods { get; set; }

    public required short TaxCollectorProspecting { get; set; }

    public required short TaxCollectorWisdom { get; set; }

    public required short BoostPoints { get; set; }

    public required IEnumerable<short> SpellId { get; set; }

    public required IEnumerable<sbyte> SpellLevel { get; set; }

    public GuildInfosUpgradeMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(MaxTaxCollectorsCount);
        writer.WriteInt8(TaxCollectorsCount);
        writer.WriteInt16(TaxCollectorLifePoints);
        writer.WriteInt16(TaxCollectorDamagesBonuses);
        writer.WriteInt16(TaxCollectorPods);
        writer.WriteInt16(TaxCollectorProspecting);
        writer.WriteInt16(TaxCollectorWisdom);
        writer.WriteInt16(BoostPoints);
        var spellIdBefore = writer.Position;
        var spellIdCount = 0;
        writer.WriteInt16(0);
        foreach (var item in SpellId)
        {
            writer.WriteInt16(item);
            spellIdCount++;
        }

        var spellIdAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, spellIdBefore);
        writer.WriteInt16((short)spellIdCount);
        writer.Seek(SeekOrigin.Begin, spellIdAfter);
        var spellLevelBefore = writer.Position;
        var spellLevelCount = 0;
        writer.WriteInt16(0);
        foreach (var item in SpellLevel)
        {
            writer.WriteInt8(item);
            spellLevelCount++;
        }

        var spellLevelAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, spellLevelBefore);
        writer.WriteInt16((short)spellLevelCount);
        writer.Seek(SeekOrigin.Begin, spellLevelAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        MaxTaxCollectorsCount = reader.ReadInt8();
        TaxCollectorsCount = reader.ReadInt8();
        TaxCollectorLifePoints = reader.ReadInt16();
        TaxCollectorDamagesBonuses = reader.ReadInt16();
        TaxCollectorPods = reader.ReadInt16();
        TaxCollectorProspecting = reader.ReadInt16();
        TaxCollectorWisdom = reader.ReadInt16();
        BoostPoints = reader.ReadInt16();
        var spellIdCount = reader.ReadInt16();
        var spellId = new short[spellIdCount];
        for (var i = 0; i < spellIdCount; i++) spellId[i] = reader.ReadInt16();
        SpellId = spellId;
        var spellLevelCount = reader.ReadInt16();
        var spellLevel = new sbyte[spellLevelCount];
        for (var i = 0; i < spellLevelCount; i++) spellLevel[i] = reader.ReadInt8();
        SpellLevel = spellLevel;
    }
}