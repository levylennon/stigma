namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeStartedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5512;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte ExchangeType { get; set; }

    public ExchangeStartedMessage()
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