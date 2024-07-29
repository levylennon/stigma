namespace Stigma.Protocol.Types.Game.Context.Fight;

public sealed class FightResultPlayerListEntry : FightResultFighterListEntry
{
    public new const ushort ProtocolTypeId = 24;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public byte Level { get; set; }

    public IEnumerable<FightResultAdditionalData> Additional { get; set; }

    public FightResultPlayerListEntry()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUInt8(Level);
        var additionalBefore = writer.Position;
        var additionalCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Additional)
        {
            writer.WriteUInt16(item.ProtocolId);
            item.Serialize(writer);
            additionalCount++;
        }

        var additionalAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, additionalBefore);
        writer.WriteInt16((short)additionalCount);
        writer.Seek(SeekOrigin.Begin, additionalAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Level = reader.ReadUInt8();
        var additionalCount = reader.ReadInt16();
        var additional = new FightResultAdditionalData[additionalCount];
        for (var i = 0; i < additionalCount; i++)
        {
            var entry = DofusTypeFactory.CreateInstance<FightResultAdditionalData>(reader.ReadUInt16());
            entry.Deserialize(reader);
            additional[i] = entry;
        }

        Additional = additional;
    }
}