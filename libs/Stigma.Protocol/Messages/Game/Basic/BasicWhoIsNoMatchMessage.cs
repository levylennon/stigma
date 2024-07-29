namespace Stigma.Protocol.Messages.Game.Basic;

public sealed class BasicWhoIsNoMatchMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 179;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string Search { get; set; }

    public BasicWhoIsNoMatchMessage()
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