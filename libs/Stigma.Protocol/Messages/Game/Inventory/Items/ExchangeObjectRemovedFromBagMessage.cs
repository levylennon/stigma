using Stigma.Protocol.Messages.Game.Inventory.Exchanges;

namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public sealed class ExchangeObjectRemovedFromBagMessage : ExchangeObjectMessage
{
    public new const uint ProtocolMessageId = 6010;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int ObjectUID { get; set; }

    public ExchangeObjectRemovedFromBagMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(ObjectUID);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        ObjectUID = reader.ReadInt32();
    }
}