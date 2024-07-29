namespace Stigma.Protocol.Messages.Game.Report;

public sealed class CharacterReportMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6079;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required uint ReportedId { get; set; }

    public required sbyte Reason { get; set; }

    public CharacterReportMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUInt32(ReportedId);
        writer.WriteInt8(Reason);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ReportedId = reader.ReadUInt32();
        Reason = reader.ReadInt8();
    }
}