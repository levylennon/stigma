namespace Stigma.Protocol.Messages.Common.Basic;

public sealed class BasicPongMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 183;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Quiet { get; set; }

    public BasicPongMessage()
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