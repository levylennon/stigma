namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ItemNoMoreAvailableMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5769;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public ItemNoMoreAvailableMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}