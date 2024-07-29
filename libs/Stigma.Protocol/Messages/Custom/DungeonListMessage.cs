using Stigma.Protocol.Types.Game.Custom;

namespace Stigma.Protocol.Messages.Custom;

public sealed class DungeonListMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6402;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<DungeonInfo> DungeonInfoValue { get; set; }

    public DungeonListMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var dungeonInfoValueBefore = writer.Position;
        var dungeonInfoValueCount = 0;
        writer.WriteInt16(0);
        foreach (var item in DungeonInfoValue)
        {
            item.Serialize(writer);
            dungeonInfoValueCount++;
        }

        var dungeonInfoValueAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, dungeonInfoValueBefore);
        writer.WriteInt16((short)dungeonInfoValueCount);
        writer.Seek(SeekOrigin.Begin, dungeonInfoValueAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var dungeonInfoValueCount = reader.ReadInt16();
        var dungeonInfoValue = new DungeonInfo[dungeonInfoValueCount];
        for (var i = 0; i < dungeonInfoValueCount; i++)
        {
            var entry = new DungeonInfo();
            entry.Deserialize(reader);
            dungeonInfoValue[i] = entry;
        }

        DungeonInfoValue = dungeonInfoValue;
    }
}