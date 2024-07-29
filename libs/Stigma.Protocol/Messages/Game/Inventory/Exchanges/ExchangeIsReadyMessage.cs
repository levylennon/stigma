namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeIsReadyMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5509;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Id { get; set; }

    public required bool Ready { get; set; }

    public ExchangeIsReadyMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Id);
        writer.WriteBoolean(Ready);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Id = reader.ReadInt32();
        Ready = reader.ReadBoolean();
    }
}