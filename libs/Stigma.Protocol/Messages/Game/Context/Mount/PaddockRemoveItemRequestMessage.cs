namespace Stigma.Protocol.Messages.Game.Context.Mount;

public sealed class PaddockRemoveItemRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5958;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short CellId { get; set; }

    public PaddockRemoveItemRequestMessage()
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