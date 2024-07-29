namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeObjectTransfertAllToInvMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6032;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public ExchangeObjectTransfertAllToInvMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}