namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Party;

public sealed class PartyLocateMembersMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5595;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<int> Geopositions { get; set; }

    public PartyLocateMembersMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var geopositionsBefore = writer.Position;
        var geopositionsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Geopositions)
        {
            writer.WriteInt32(item);
            geopositionsCount++;
        }

        var geopositionsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, geopositionsBefore);
        writer.WriteInt16((short)geopositionsCount);
        writer.Seek(SeekOrigin.Begin, geopositionsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var geopositionsCount = reader.ReadInt16();
        var geopositions = new int[geopositionsCount];
        for (var i = 0; i < geopositionsCount; i++) geopositions[i] = reader.ReadInt32();
        Geopositions = geopositions;
    }
}