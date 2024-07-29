namespace Stigma.Protocol.Messages.Game.Pvp;

public sealed class AlignmentSubAreasListMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6059;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<short> AngelsSubAreas { get; set; }

    public required IEnumerable<short> EvilsSubAreas { get; set; }

    public AlignmentSubAreasListMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var angelsSubAreasBefore = writer.Position;
        var angelsSubAreasCount = 0;
        writer.WriteInt16(0);
        foreach (var item in AngelsSubAreas)
        {
            writer.WriteInt16(item);
            angelsSubAreasCount++;
        }

        var angelsSubAreasAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, angelsSubAreasBefore);
        writer.WriteInt16((short)angelsSubAreasCount);
        writer.Seek(SeekOrigin.Begin, angelsSubAreasAfter);
        var evilsSubAreasBefore = writer.Position;
        var evilsSubAreasCount = 0;
        writer.WriteInt16(0);
        foreach (var item in EvilsSubAreas)
        {
            writer.WriteInt16(item);
            evilsSubAreasCount++;
        }

        var evilsSubAreasAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, evilsSubAreasBefore);
        writer.WriteInt16((short)evilsSubAreasCount);
        writer.Seek(SeekOrigin.Begin, evilsSubAreasAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var angelsSubAreasCount = reader.ReadInt16();
        var angelsSubAreas = new short[angelsSubAreasCount];
        for (var i = 0; i < angelsSubAreasCount; i++) angelsSubAreas[i] = reader.ReadInt16();
        AngelsSubAreas = angelsSubAreas;
        var evilsSubAreasCount = reader.ReadInt16();
        var evilsSubAreas = new short[evilsSubAreasCount];
        for (var i = 0; i < evilsSubAreasCount; i++) evilsSubAreas[i] = reader.ReadInt16();
        EvilsSubAreas = evilsSubAreas;
    }
}