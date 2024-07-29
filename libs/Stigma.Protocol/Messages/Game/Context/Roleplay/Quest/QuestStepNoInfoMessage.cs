namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Quest;

public sealed class QuestStepNoInfoMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5627;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short QuestId { get; set; }

    public QuestStepNoInfoMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(QuestId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        QuestId = reader.ReadInt16();
    }
}