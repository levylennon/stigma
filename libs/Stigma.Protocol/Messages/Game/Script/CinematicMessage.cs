namespace Stigma.Protocol.Messages.Game.Script;

public sealed class CinematicMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6053;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short CinematicId { get; set; }

    public CinematicMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(CinematicId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        CinematicId = reader.ReadInt16();
    }
}