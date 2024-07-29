namespace Stigma.Protocol.Messages.Game.Basic;

public sealed class BasicWhoIsRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 181;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string Search { get; set; }

    public BasicWhoIsRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUtf(Search);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Search = reader.ReadUtf();
    }
}