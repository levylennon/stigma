using Stigma.Protocol.Types.Game.Context.Fight;

namespace Stigma.Protocol.Messages.Game.Context.Fight;

public sealed class GameFightEndMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 720;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Duration { get; set; }

    public required short AgeBonus { get; set; }

    public required IEnumerable<FightResultListEntry> Results { get; set; }

    public GameFightEndMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Duration);
        writer.WriteInt16(AgeBonus);
        var resultsBefore = writer.Position;
        var resultsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Results)
        {
            writer.WriteUInt16(item.ProtocolId);
            item.Serialize(writer);
            resultsCount++;
        }

        var resultsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, resultsBefore);
        writer.WriteInt16((short)resultsCount);
        writer.Seek(SeekOrigin.Begin, resultsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Duration = reader.ReadInt32();
        AgeBonus = reader.ReadInt16();
        var resultsCount = reader.ReadInt16();
        var results = new FightResultListEntry[resultsCount];
        for (var i = 0; i < resultsCount; i++)
        {
            var entry = DofusTypeFactory.CreateInstance<FightResultListEntry>(reader.ReadUInt16());
            entry.Deserialize(reader);
            results[i] = entry;
        }

        Results = results;
    }
}