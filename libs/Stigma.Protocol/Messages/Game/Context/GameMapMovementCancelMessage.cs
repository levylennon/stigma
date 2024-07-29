namespace Stigma.Protocol.Messages.Game.Context;

public sealed class GameMapMovementCancelMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 953;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short CellId { get; set; }

    public GameMapMovementCancelMessage()
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