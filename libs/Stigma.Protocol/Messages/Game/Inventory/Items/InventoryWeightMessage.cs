namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public sealed class InventoryWeightMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 3009;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Weight { get; set; }

    public required int WeightMax { get; set; }

    public InventoryWeightMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Weight);
        writer.WriteInt32(WeightMax);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Weight = reader.ReadInt32();
        WeightMax = reader.ReadInt32();
    }
}