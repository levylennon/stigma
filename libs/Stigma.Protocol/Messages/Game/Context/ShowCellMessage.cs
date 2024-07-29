namespace Stigma.Protocol.Messages.Game.Context;

public sealed class ShowCellMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5612;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int SourceId { get; set; }

    public required short CellId { get; set; }

    public ShowCellMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(SourceId);
        writer.WriteInt16(CellId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        SourceId = reader.ReadInt32();
        CellId = reader.ReadInt16();
    }
}