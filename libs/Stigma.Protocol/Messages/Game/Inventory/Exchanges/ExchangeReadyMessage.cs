namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeReadyMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5511;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Ready { get; set; }

    public ExchangeReadyMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(Ready);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Ready = reader.ReadBoolean();
    }
}