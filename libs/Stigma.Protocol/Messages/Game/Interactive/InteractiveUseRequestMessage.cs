namespace Stigma.Protocol.Messages.Game.Interactive;

public sealed class InteractiveUseRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5001;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int ElemId { get; set; }

    public required short SkillId { get; set; }

    public InteractiveUseRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(ElemId);
        writer.WriteInt16(SkillId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ElemId = reader.ReadInt32();
        SkillId = reader.ReadInt16();
    }
}