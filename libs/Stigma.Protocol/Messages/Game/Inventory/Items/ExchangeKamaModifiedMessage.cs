using Stigma.Protocol.Messages.Game.Inventory.Exchanges;

namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public sealed class ExchangeKamaModifiedMessage : ExchangeObjectMessage
{
    public new const uint ProtocolMessageId = 5521;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Quantity { get; set; }

    public ExchangeKamaModifiedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(Quantity);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Quantity = reader.ReadInt32();
    }
}