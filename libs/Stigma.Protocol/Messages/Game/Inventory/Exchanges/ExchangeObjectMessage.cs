namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public class ExchangeObjectMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5515;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Remote { get; set; }

    public ExchangeObjectMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(Remote);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Remote = reader.ReadBoolean();
    }
}