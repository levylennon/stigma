namespace Stigma.Protocol.Messages.Game.Interactive.Zaap;

public class TeleportDestinationsListMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5960;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte TeleporterType { get; set; }

    public required IEnumerable<int> MapIds { get; set; }

    public required IEnumerable<short> SubareaIds { get; set; }

    public required IEnumerable<short> Costs { get; set; }

    public TeleportDestinationsListMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(TeleporterType);
        var mapIdsBefore = writer.Position;
        var mapIdsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in MapIds)
        {
            writer.WriteInt32(item);
            mapIdsCount++;
        }

        var mapIdsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, mapIdsBefore);
        writer.WriteInt16((short)mapIdsCount);
        writer.Seek(SeekOrigin.Begin, mapIdsAfter);
        var subareaIdsBefore = writer.Position;
        var subareaIdsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in SubareaIds)
        {
            writer.WriteInt16(item);
            subareaIdsCount++;
        }

        var subareaIdsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, subareaIdsBefore);
        writer.WriteInt16((short)subareaIdsCount);
        writer.Seek(SeekOrigin.Begin, subareaIdsAfter);
        var costsBefore = writer.Position;
        var costsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Costs)
        {
            writer.WriteInt16(item);
            costsCount++;
        }

        var costsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, costsBefore);
        writer.WriteInt16((short)costsCount);
        writer.Seek(SeekOrigin.Begin, costsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        TeleporterType = reader.ReadInt8();
        var mapIdsCount = reader.ReadInt16();
        var mapIds = new int[mapIdsCount];
        for (var i = 0; i < mapIdsCount; i++) mapIds[i] = reader.ReadInt32();
        MapIds = mapIds;
        var subareaIdsCount = reader.ReadInt16();
        var subareaIds = new short[subareaIdsCount];
        for (var i = 0; i < subareaIdsCount; i++) subareaIds[i] = reader.ReadInt16();
        SubareaIds = subareaIds;
        var costsCount = reader.ReadInt16();
        var costs = new short[costsCount];
        for (var i = 0; i < costsCount; i++) costs[i] = reader.ReadInt16();
        Costs = costs;
    }
}