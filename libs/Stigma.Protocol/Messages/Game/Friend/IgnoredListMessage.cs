using Stigma.Protocol.Types.Game.Friend;

namespace Stigma.Protocol.Messages.Game.Friend;

public sealed class IgnoredListMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5674;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<IgnoredInformations> IgnoredList { get; set; }

    public IgnoredListMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var ignoredListBefore = writer.Position;
        var ignoredListCount = 0;
        writer.WriteInt16(0);
        foreach (var item in IgnoredList)
        {
            writer.WriteUInt16(item.ProtocolId);
            item.Serialize(writer);
            ignoredListCount++;
        }

        var ignoredListAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, ignoredListBefore);
        writer.WriteInt16((short)ignoredListCount);
        writer.Seek(SeekOrigin.Begin, ignoredListAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var ignoredListCount = reader.ReadInt16();
        var ignoredList = new IgnoredInformations[ignoredListCount];
        for (var i = 0; i < ignoredListCount; i++)
        {
            var entry = DofusTypeFactory.CreateInstance<IgnoredInformations>(reader.ReadUInt16());
            entry.Deserialize(reader);
            ignoredList[i] = entry;
        }

        IgnoredList = ignoredList;
    }
}