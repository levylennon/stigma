using Stigma.Protocol.Types.Game.Prism;

namespace Stigma.Protocol.Messages.Game.Prism;

public sealed class PrismWorldInformationMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5854;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int NbSubOwned { get; set; }

    public required int SubTotal { get; set; }

    public required int MaxSub { get; set; }

    public required IEnumerable<PrismSubAreaInformation> SubAreasInformation { get; set; }

    public required int NbConqsOwned { get; set; }

    public required int ConqsTotal { get; set; }

    public required IEnumerable<PrismConquestInformation> ConquetesInformation { get; set; }

    public PrismWorldInformationMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(NbSubOwned);
        writer.WriteInt32(SubTotal);
        writer.WriteInt32(MaxSub);
        var subAreasInformationBefore = writer.Position;
        var subAreasInformationCount = 0;
        writer.WriteInt16(0);
        foreach (var item in SubAreasInformation)
        {
            item.Serialize(writer);
            subAreasInformationCount++;
        }

        var subAreasInformationAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, subAreasInformationBefore);
        writer.WriteInt16((short)subAreasInformationCount);
        writer.Seek(SeekOrigin.Begin, subAreasInformationAfter);
        writer.WriteInt32(NbConqsOwned);
        writer.WriteInt32(ConqsTotal);
        var conquetesInformationBefore = writer.Position;
        var conquetesInformationCount = 0;
        writer.WriteInt16(0);
        foreach (var item in ConquetesInformation)
        {
            item.Serialize(writer);
            conquetesInformationCount++;
        }

        var conquetesInformationAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, conquetesInformationBefore);
        writer.WriteInt16((short)conquetesInformationCount);
        writer.Seek(SeekOrigin.Begin, conquetesInformationAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        NbSubOwned = reader.ReadInt32();
        SubTotal = reader.ReadInt32();
        MaxSub = reader.ReadInt32();
        var subAreasInformationCount = reader.ReadInt16();
        var subAreasInformation = new PrismSubAreaInformation[subAreasInformationCount];
        for (var i = 0; i < subAreasInformationCount; i++)
        {
            var entry = new PrismSubAreaInformation();
            entry.Deserialize(reader);
            subAreasInformation[i] = entry;
        }

        SubAreasInformation = subAreasInformation;
        NbConqsOwned = reader.ReadInt32();
        ConqsTotal = reader.ReadInt32();
        var conquetesInformationCount = reader.ReadInt16();
        var conquetesInformation = new PrismConquestInformation[conquetesInformationCount];
        for (var i = 0; i < conquetesInformationCount; i++)
        {
            var entry = new PrismConquestInformation();
            entry.Deserialize(reader);
            conquetesInformation[i] = entry;
        }

        ConquetesInformation = conquetesInformation;
    }
}