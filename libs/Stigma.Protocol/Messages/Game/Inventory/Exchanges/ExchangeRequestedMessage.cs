namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public class ExchangeRequestedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5522;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte ExchangeType { get; set; }

    public ExchangeRequestedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(ExchangeType);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ExchangeType = reader.ReadInt8();
    }
}