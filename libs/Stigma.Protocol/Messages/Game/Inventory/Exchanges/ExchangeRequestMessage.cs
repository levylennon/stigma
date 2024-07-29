namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public class ExchangeRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5505;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte ExchangeType { get; set; }

    public ExchangeRequestMessage()
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