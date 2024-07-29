namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Document;

public sealed class DocumentReadingBeginMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5675;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short DocumentId { get; set; }

    public DocumentReadingBeginMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(DocumentId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        DocumentId = reader.ReadInt16();
    }
}