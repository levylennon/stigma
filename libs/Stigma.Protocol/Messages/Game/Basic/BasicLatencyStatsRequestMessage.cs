namespace Stigma.Protocol.Messages.Game.Basic;

public sealed class BasicLatencyStatsRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5816;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public BasicLatencyStatsRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}