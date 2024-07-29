namespace Stigma.Protocol.Messages.Common.Basic;

public sealed class BasicPingMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 182;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Quiet { get; set; }

    public BasicPingMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(Quiet);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Quiet = reader.ReadBoolean();
    }
}