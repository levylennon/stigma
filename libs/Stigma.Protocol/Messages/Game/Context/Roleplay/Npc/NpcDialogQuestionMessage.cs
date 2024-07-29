namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Npc;

public sealed class NpcDialogQuestionMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5617;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short MessageId { get; set; }

    public required IEnumerable<string> DialogParams { get; set; }

    public required IEnumerable<short> VisibleReplies { get; set; }

    public NpcDialogQuestionMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(MessageId);
        var dialogParamsBefore = writer.Position;
        var dialogParamsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in DialogParams)
        {
            writer.WriteUtf(item);
            dialogParamsCount++;
        }

        var dialogParamsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, dialogParamsBefore);
        writer.WriteInt16((short)dialogParamsCount);
        writer.Seek(SeekOrigin.Begin, dialogParamsAfter);
        var visibleRepliesBefore = writer.Position;
        var visibleRepliesCount = 0;
        writer.WriteInt16(0);
        foreach (var item in VisibleReplies)
        {
            writer.WriteInt16(item);
            visibleRepliesCount++;
        }

        var visibleRepliesAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, visibleRepliesBefore);
        writer.WriteInt16((short)visibleRepliesCount);
        writer.Seek(SeekOrigin.Begin, visibleRepliesAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        MessageId = reader.ReadInt16();
        var dialogParamsCount = reader.ReadInt16();
        var dialogParams = new string[dialogParamsCount];
        for (var i = 0; i < dialogParamsCount; i++) dialogParams[i] = reader.ReadUtf();
        DialogParams = dialogParams;
        var visibleRepliesCount = reader.ReadInt16();
        var visibleReplies = new short[visibleRepliesCount];
        for (var i = 0; i < visibleRepliesCount; i++) visibleReplies[i] = reader.ReadInt16();
        VisibleReplies = visibleReplies;
    }
}