namespace Stigma.Protocol.Messages.Game.Context.Fight;

public sealed class GameFightPlacementPositionRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 704;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short CellId { get; set; }

    public GameFightPlacementPositionRequestMessage()
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