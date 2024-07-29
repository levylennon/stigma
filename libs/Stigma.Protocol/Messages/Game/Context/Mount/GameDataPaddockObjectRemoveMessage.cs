namespace Stigma.Protocol.Messages.Game.Context.Mount;

public sealed class GameDataPaddockObjectRemoveMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5993;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short CellId { get; set; }

    public GameDataPaddockObjectRemoveMessage()
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