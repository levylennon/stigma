namespace Stigma.Protocol.Messages.Game.Context;

public sealed class ShowCellRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5611;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short CellId { get; set; }

    public ShowCellRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(CellId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        CellId = reader.ReadInt16();
    }
}