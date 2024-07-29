namespace Stigma.Protocol.Messages.Game.Basic;

public sealed class BasicLatencyStatsMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5663;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required ushort Latency { get; set; }

    public required short SampleCount { get; set; }

    public required short Max { get; set; }

    public BasicLatencyStatsMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUInt16(Latency);
        writer.WriteInt16(SampleCount);
        writer.WriteInt16(Max);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Latency = reader.ReadUInt16();
        SampleCount = reader.ReadInt16();
        Max = reader.ReadInt16();
    }
}