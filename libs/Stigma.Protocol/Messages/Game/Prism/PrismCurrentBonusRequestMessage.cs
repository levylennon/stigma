namespace Stigma.Protocol.Messages.Game.Prism;

public sealed class PrismCurrentBonusRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5840;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public PrismCurrentBonusRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}