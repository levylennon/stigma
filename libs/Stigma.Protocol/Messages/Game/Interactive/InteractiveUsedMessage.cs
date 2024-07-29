namespace Stigma.Protocol.Messages.Game.Interactive;

public sealed class InteractiveUsedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5745;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int EntityId { get; set; }

    public required int ElemId { get; set; }

    public required short SkillId { get; set; }

    public required short Duration { get; set; }

    public InteractiveUsedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(EntityId);
        writer.WriteInt32(ElemId);
        writer.WriteInt16(SkillId);
        writer.WriteInt16(Duration);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        EntityId = reader.ReadInt32();
        ElemId = reader.ReadInt32();
        SkillId = reader.ReadInt16();
        Duration = reader.ReadInt16();
    }
}