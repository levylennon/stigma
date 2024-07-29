namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeWaitingResultMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5786;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Bwait { get; set; }

    public ExchangeWaitingResultMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(Bwait);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Bwait = reader.ReadBoolean();
    }
}