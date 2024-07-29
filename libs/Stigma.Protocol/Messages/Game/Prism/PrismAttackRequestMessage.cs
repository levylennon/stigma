namespace Stigma.Protocol.Messages.Game.Prism;

public sealed class PrismAttackRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6042;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public PrismAttackRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}