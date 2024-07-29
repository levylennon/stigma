namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Quest;

public sealed class QuestObjectiveValidatedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6098;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required ushort QuestId { get; set; }

    public required ushort ObjectiveId { get; set; }

    public QuestObjectiveValidatedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUInt16(QuestId);
        writer.WriteUInt16(ObjectiveId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        QuestId = reader.ReadUInt16();
        ObjectiveId = reader.ReadUInt16();
    }
}