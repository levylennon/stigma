namespace Stigma.Protocol.Messages.Game.Guild.Tax;

public sealed class TaxCollectorHireRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5681;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public TaxCollectorHireRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}