namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Quest;

public sealed class QuestStepInfoRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5622;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required ushort QuestId { get; set; }

    public QuestStepInfoRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUInt16(QuestId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        QuestId = reader.ReadUInt16();
    }
}