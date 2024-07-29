namespace Stigma.Protocol.Messages.Game.Basic;

public sealed class BasicTimeMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 175;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Timestamp { get; set; }

    public required short TimezoneOffset { get; set; }

    public BasicTimeMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Timestamp);
        writer.WriteInt16(TimezoneOffset);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Timestamp = reader.ReadInt32();
        TimezoneOffset = reader.ReadInt16();
    }
}