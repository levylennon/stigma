namespace Stigma.Protocol.Messages.Game.Prism;

public sealed class PrismBalanceRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5839;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public PrismBalanceRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}