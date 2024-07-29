namespace Stigma.Protocol.Types.Game.Look;

public sealed class EntityLook : DofusType
{
    public new const ushort ProtocolTypeId = 55;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short BonesId { get; set; }

    public IEnumerable<short> Skins { get; set; }

    public IEnumerable<int> IndexedColors { get; set; }

    public IEnumerable<short> Scales { get; set; }

    public IEnumerable<SubEntity> Subentities { get; set; }

    public EntityLook()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(BonesId);
        var skinsBefore = writer.Position;
        var skinsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Skins)
        {
            writer.WriteInt16(item);
            skinsCount++;
        }

        var skinsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, skinsBefore);
        writer.WriteInt16((short)skinsCount);
        writer.Seek(SeekOrigin.Begin, skinsAfter);
        var indexedColorsBefore = writer.Position;
        var indexedColorsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in IndexedColors)
        {
            writer.WriteInt32(item);
            indexedColorsCount++;
        }

        var indexedColorsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, indexedColorsBefore);
        writer.WriteInt16((short)indexedColorsCount);
        writer.Seek(SeekOrigin.Begin, indexedColorsAfter);
        var scalesBefore = writer.Position;
        var scalesCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Scales)
        {
            writer.WriteInt16(item);
            scalesCount++;
        }

        var scalesAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, scalesBefore);
        writer.WriteInt16((short)scalesCount);
        writer.Seek(SeekOrigin.Begin, scalesAfter);
        var subentitiesBefore = writer.Position;
        var subentitiesCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Subentities)
        {
            item.Serialize(writer);
            subentitiesCount++;
        }

        var subentitiesAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, subentitiesBefore);
        writer.WriteInt16((short)subentitiesCount);
        writer.Seek(SeekOrigin.Begin, subentitiesAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        BonesId = reader.ReadInt16();
        var skinsCount = reader.ReadInt16();
        var skins = new short[skinsCount];
        for (var i = 0; i < skinsCount; i++) skins[i] = reader.ReadInt16();
        Skins = skins;
        var indexedColorsCount = reader.ReadInt16();
        var indexedColors = new int[indexedColorsCount];
        for (var i = 0; i < indexedColorsCount; i++) indexedColors[i] = reader.ReadInt32();
        IndexedColors = indexedColors;
        var scalesCount = reader.ReadInt16();
        var scales = new short[scalesCount];
        for (var i = 0; i < scalesCount; i++) scales[i] = reader.ReadInt16();
        Scales = scales;
        var subentitiesCount = reader.ReadInt16();
        var subentities = new SubEntity[subentitiesCount];
        for (var i = 0; i < subentitiesCount; i++)
        {
            var entry = new SubEntity();
            entry.Deserialize(reader);
            subentities[i] = entry;
        }

        Subentities = subentities;
    }
}