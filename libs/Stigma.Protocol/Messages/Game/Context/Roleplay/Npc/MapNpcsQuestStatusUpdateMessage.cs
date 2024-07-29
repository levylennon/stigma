namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Npc;

public sealed class MapNpcsQuestStatusUpdateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5642;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int MapId { get; set; }

    public required IEnumerable<int> NpcsIdsCanGiveQuest { get; set; }

    public required IEnumerable<int> NpcsIdsCannotGiveQuest { get; set; }

    public MapNpcsQuestStatusUpdateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(MapId);
        var npcsIdsCanGiveQuestBefore = writer.Position;
        var npcsIdsCanGiveQuestCount = 0;
        writer.WriteInt16(0);
        foreach (var item in NpcsIdsCanGiveQuest)
        {
            writer.WriteInt32(item);
            npcsIdsCanGiveQuestCount++;
        }

        var npcsIdsCanGiveQuestAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, npcsIdsCanGiveQuestBefore);
        writer.WriteInt16((short)npcsIdsCanGiveQuestCount);
        writer.Seek(SeekOrigin.Begin, npcsIdsCanGiveQuestAfter);
        var npcsIdsCannotGiveQuestBefore = writer.Position;
        var npcsIdsCannotGiveQuestCount = 0;
        writer.WriteInt16(0);
        foreach (var item in NpcsIdsCannotGiveQuest)
        {
            writer.WriteInt32(item);
            npcsIdsCannotGiveQuestCount++;
        }

        var npcsIdsCannotGiveQuestAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, npcsIdsCannotGiveQuestBefore);
        writer.WriteInt16((short)npcsIdsCannotGiveQuestCount);
        writer.Seek(SeekOrigin.Begin, npcsIdsCannotGiveQuestAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        MapId = reader.ReadInt32();
        var npcsIdsCanGiveQuestCount = reader.ReadInt16();
        var npcsIdsCanGiveQuest = new int[npcsIdsCanGiveQuestCount];
        for (var i = 0; i < npcsIdsCanGiveQuestCount; i++) npcsIdsCanGiveQuest[i] = reader.ReadInt32();
        NpcsIdsCanGiveQuest = npcsIdsCanGiveQuest;
        var npcsIdsCannotGiveQuestCount = reader.ReadInt16();
        var npcsIdsCannotGiveQuest = new int[npcsIdsCannotGiveQuestCount];
        for (var i = 0; i < npcsIdsCannotGiveQuestCount; i++) npcsIdsCannotGiveQuest[i] = reader.ReadInt32();
        NpcsIdsCannotGiveQuest = npcsIdsCannotGiveQuest;
    }
}