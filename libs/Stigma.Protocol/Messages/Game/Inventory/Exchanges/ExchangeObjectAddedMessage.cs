using Stigma.Protocol.Types.Game.Data.Items;

namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeObjectAddedMessage : ExchangeObjectMessage
{
    public new const uint ProtocolMessageId = 5516;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required ObjectItem Object { get; set; }

    public ExchangeObjectAddedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        Object.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Object = new ObjectItem();
        Object.Deserialize(reader);
    }
}