namespace Stigma.Protocol.Messages.Game.Prism;

public sealed class PrismInfoCloseMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5853;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public PrismInfoCloseMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}