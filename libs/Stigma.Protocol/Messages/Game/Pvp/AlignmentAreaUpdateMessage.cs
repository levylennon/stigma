namespace Stigma.Protocol.Messages.Game.Pvp;

public sealed class AlignmentAreaUpdateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6060;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short AreaId { get; set; }

    public required sbyte Side { get; set; }

    public AlignmentAreaUpdateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(AreaId);
        writer.WriteInt8(Side);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        AreaId = reader.ReadInt16();
        Side = reader.ReadInt8();
    }
}