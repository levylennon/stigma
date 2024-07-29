namespace Stigma.Protocol.Messages.Game.Prism;

public sealed class PrismUseRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6041;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public PrismUseRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}