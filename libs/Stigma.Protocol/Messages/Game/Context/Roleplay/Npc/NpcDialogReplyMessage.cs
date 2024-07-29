namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Npc;

public sealed class NpcDialogReplyMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5616;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short ReplyId { get; set; }

    public NpcDialogReplyMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(ReplyId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ReplyId = reader.ReadInt16();
    }
}