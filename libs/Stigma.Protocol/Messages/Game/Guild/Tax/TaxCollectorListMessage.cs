using Stigma.Protocol.Types.Game.Guild.Tax;

namespace Stigma.Protocol.Messages.Game.Guild.Tax;

public sealed class TaxCollectorListMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5930;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte NbcollectorMax { get; set; }

    public required short TaxCollectorHireCost { get; set; }

    public required IEnumerable<TaxCollectorInformations> Informations { get; set; }

    public required IEnumerable<TaxCollectorFightersInformation> FightersInformations { get; set; }

    public TaxCollectorListMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(NbcollectorMax);
        writer.WriteInt16(TaxCollectorHireCost);
        var informationsBefore = writer.Position;
        var informationsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Informations)
        {
            writer.WriteUInt16(item.ProtocolId);
            item.Serialize(writer);
            informationsCount++;
        }

        var informationsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, informationsBefore);
        writer.WriteInt16((short)informationsCount);
        writer.Seek(SeekOrigin.Begin, informationsAfter);
        var fightersInformationsBefore = writer.Position;
        var fightersInformationsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in FightersInformations)
        {
            item.Serialize(writer);
            fightersInformationsCount++;
        }

        var fightersInformationsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, fightersInformationsBefore);
        writer.WriteInt16((short)fightersInformationsCount);
        writer.Seek(SeekOrigin.Begin, fightersInformationsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        NbcollectorMax = reader.ReadInt8();
        TaxCollectorHireCost = reader.ReadInt16();
        var informationsCount = reader.ReadInt16();
        var informations = new TaxCollectorInformations[informationsCount];
        for (var i = 0; i < informationsCount; i++)
        {
            var entry = DofusTypeFactory.CreateInstance<TaxCollectorInformations>(reader.ReadUInt16());
            entry.Deserialize(reader);
            informations[i] = entry;
        }

        Informations = informations;
        var fightersInformationsCount = reader.ReadInt16();
        var fightersInformations = new TaxCollectorFightersInformation[fightersInformationsCount];
        for (var i = 0; i < fightersInformationsCount; i++)
        {
            var entry = new TaxCollectorFightersInformation();
            entry.Deserialize(reader);
            fightersInformations[i] = entry;
        }

        FightersInformations = fightersInformations;
    }
}