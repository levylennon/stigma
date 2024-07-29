using Stigma.Protocol.Types.Game.Context.Roleplay.Job;

namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Job;

public sealed class JobCrafterDirectoryListMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6046;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<JobCrafterDirectoryListEntry> ListEntries { get; set; }

    public JobCrafterDirectoryListMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var listEntriesBefore = writer.Position;
        var listEntriesCount = 0;
        writer.WriteInt16(0);
        foreach (var item in ListEntries)
        {
            item.Serialize(writer);
            listEntriesCount++;
        }

        var listEntriesAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, listEntriesBefore);
        writer.WriteInt16((short)listEntriesCount);
        writer.Seek(SeekOrigin.Begin, listEntriesAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var listEntriesCount = reader.ReadInt16();
        var listEntries = new JobCrafterDirectoryListEntry[listEntriesCount];
        for (var i = 0; i < listEntriesCount; i++)
        {
            var entry = new JobCrafterDirectoryListEntry();
            entry.Deserialize(reader);
            listEntries[i] = entry;
        }

        ListEntries = listEntries;
    }
}