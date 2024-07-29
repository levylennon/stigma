namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Quest;

public sealed class QuestStepValidatedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6099;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required ushort QuestId { get; set; }

    public required ushort StepId { get; set; }

    public QuestStepValidatedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUInt16(QuestId);
        writer.WriteUInt16(StepId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        QuestId = reader.ReadUInt16();
        StepId = reader.ReadUInt16();
    }
}