using Stigma.Protocol.Types.Game.Data.Items;

namespace Stigma.Protocol.Messages.Game.Inventory.Spells;

public sealed class SpellListMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 1200;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool SpellPrevisualization { get; set; }

    public required IEnumerable<SpellItem> Spells { get; set; }

    public SpellListMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(SpellPrevisualization);
        var spellsBefore = writer.Position;
        var spellsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Spells)
        {
            item.Serialize(writer);
            spellsCount++;
        }

        var spellsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, spellsBefore);
        writer.WriteInt16((short)spellsCount);
        writer.Seek(SeekOrigin.Begin, spellsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        SpellPrevisualization = reader.ReadBoolean();
        var spellsCount = reader.ReadInt16();
        var spells = new SpellItem[spellsCount];
        for (var i = 0; i < spellsCount; i++)
        {
            var entry = new SpellItem();
            entry.Deserialize(reader);
            spells[i] = entry;
        }

        Spells = spells;
    }
}