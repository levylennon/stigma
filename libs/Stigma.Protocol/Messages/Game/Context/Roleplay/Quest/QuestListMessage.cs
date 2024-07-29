namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Quest;

public sealed class QuestListMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5626;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<short> FinishedQuestsIds { get; set; }

    public required IEnumerable<short> ActiveQuestsIds { get; set; }

    public QuestListMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var finishedQuestsIdsBefore = writer.Position;
        var finishedQuestsIdsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in FinishedQuestsIds)
        {
            writer.WriteInt16(item);
            finishedQuestsIdsCount++;
        }

        var finishedQuestsIdsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, finishedQuestsIdsBefore);
        writer.WriteInt16((short)finishedQuestsIdsCount);
        writer.Seek(SeekOrigin.Begin, finishedQuestsIdsAfter);
        var activeQuestsIdsBefore = writer.Position;
        var activeQuestsIdsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in ActiveQuestsIds)
        {
            writer.WriteInt16(item);
            activeQuestsIdsCount++;
        }

        var activeQuestsIdsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, activeQuestsIdsBefore);
        writer.WriteInt16((short)activeQuestsIdsCount);
        writer.Seek(SeekOrigin.Begin, activeQuestsIdsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var finishedQuestsIdsCount = reader.ReadInt16();
        var finishedQuestsIds = new short[finishedQuestsIdsCount];
        for (var i = 0; i < finishedQuestsIdsCount; i++) finishedQuestsIds[i] = reader.ReadInt16();
        FinishedQuestsIds = finishedQuestsIds;
        var activeQuestsIdsCount = reader.ReadInt16();
        var activeQuestsIds = new short[activeQuestsIdsCount];
        for (var i = 0; i < activeQuestsIdsCount; i++) activeQuestsIds[i] = reader.ReadInt16();
        ActiveQuestsIds = activeQuestsIds;
    }
}