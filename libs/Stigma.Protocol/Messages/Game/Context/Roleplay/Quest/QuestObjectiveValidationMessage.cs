namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Quest;

public sealed class QuestObjectiveValidationMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6085;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short QuestId { get; set; }

    public required short ObjectiveId { get; set; }

    public QuestObjectiveValidationMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(QuestId);
        writer.WriteInt16(ObjectiveId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        QuestId = reader.ReadInt16();
        ObjectiveId = reader.ReadInt16();
    }
}