namespace Stigma.Protocol.Messages.Game.Pvp;

public sealed class AlignmentSubAreaUpdateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6057;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short SubAreaId { get; set; }

    public required sbyte Side { get; set; }

    public required bool Quiet { get; set; }

    public AlignmentSubAreaUpdateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(SubAreaId);
        writer.WriteInt8(Side);
        writer.WriteBoolean(Quiet);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        SubAreaId = reader.ReadInt16();
        Side = reader.ReadInt8();
        Quiet = reader.ReadBoolean();
    }
}