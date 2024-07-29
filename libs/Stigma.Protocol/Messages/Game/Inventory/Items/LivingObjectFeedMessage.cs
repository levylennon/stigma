namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public sealed class LivingObjectFeedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5724;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int LivingUID { get; set; }

    public required byte LivingPosition { get; set; }

    public required int FoodUID { get; set; }

    public LivingObjectFeedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(LivingUID);
        writer.WriteUInt8(LivingPosition);
        writer.WriteInt32(FoodUID);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        LivingUID = reader.ReadInt32();
        LivingPosition = reader.ReadUInt8();
        FoodUID = reader.ReadInt32();
    }
}