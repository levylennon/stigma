namespace Stigma.Protocol.Messages.Game.Context.Mount;

public sealed class PaddockBuyRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5951;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public PaddockBuyRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}