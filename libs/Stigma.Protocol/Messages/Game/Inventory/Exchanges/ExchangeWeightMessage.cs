namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeWeightMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5793;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int CurrentWeight { get; set; }

    public required int MaxWeight { get; set; }

    public ExchangeWeightMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(CurrentWeight);
        writer.WriteInt32(MaxWeight);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        CurrentWeight = reader.ReadInt32();
        MaxWeight = reader.ReadInt32();
    }
}