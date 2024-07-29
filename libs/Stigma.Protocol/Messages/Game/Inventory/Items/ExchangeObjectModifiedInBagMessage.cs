using Stigma.Protocol.Messages.Game.Inventory.Exchanges;
using Stigma.Protocol.Types.Game.Data.Items;

namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public sealed class ExchangeObjectModifiedInBagMessage : ExchangeObjectMessage
{
    public new const uint ProtocolMessageId = 6008;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required ObjectItem Object { get; set; }

    public ExchangeObjectModifiedInBagMessage()
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