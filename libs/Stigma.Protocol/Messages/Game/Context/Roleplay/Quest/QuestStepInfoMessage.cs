namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Quest;

public sealed class QuestStepInfoMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5625;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short QuestId { get; set; }

    public required short StepId { get; set; }

    public required IEnumerable<short> ObjectivesIds { get; set; }

    public required IEnumerable<bool> ObjectivesStatus { get; set; }

    public QuestStepInfoMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(QuestId);
        writer.WriteInt16(StepId);
        var objectivesIdsBefore = writer.Position;
        var objectivesIdsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in ObjectivesIds)
        {
            writer.WriteInt16(item);
            objectivesIdsCount++;
        }

        var objectivesIdsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, objectivesIdsBefore);
        writer.WriteInt16((short)objectivesIdsCount);
        writer.Seek(SeekOrigin.Begin, objectivesIdsAfter);
        var objectivesStatusBefore = writer.Position;
        var objectivesStatusCount = 0;
        writer.WriteInt16(0);
        foreach (var item in ObjectivesStatus)
        {
            writer.WriteBoolean(item);
            objectivesStatusCount++;
        }

        var objectivesStatusAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, objectivesStatusBefore);
        writer.WriteInt16((short)objectivesStatusCount);
        writer.Seek(SeekOrigin.Begin, objectivesStatusAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        QuestId = reader.ReadInt16();
        StepId = reader.ReadInt16();
        var objectivesIdsCount = reader.ReadInt16();
        var objectivesIds = new short[objectivesIdsCount];
        for (var i = 0; i < objectivesIdsCount; i++) objectivesIds[i] = reader.ReadInt16();
        ObjectivesIds = objectivesIds;
        var objectivesStatusCount = reader.ReadInt16();
        var objectivesStatus = new bool[objectivesStatusCount];
        for (var i = 0; i < objectivesStatusCount; i++) objectivesStatus[i] = reader.ReadBoolean();
        ObjectivesStatus = objectivesStatus;
    }
}