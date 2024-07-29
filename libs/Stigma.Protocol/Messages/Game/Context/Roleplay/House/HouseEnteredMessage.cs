namespace Stigma.Protocol.Messages.Game.Context.Roleplay.House;

public sealed class HouseEnteredMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5860;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int OwnerId { get; set; }

    public required string OwnerName { get; set; }

    public required uint Price { get; set; }

    public required bool IsLocked { get; set; }

    public required short WorldX { get; set; }

    public required short WorldY { get; set; }

    public required short ModelId { get; set; }

    public HouseEnteredMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(OwnerId);
        writer.WriteUtf(OwnerName);
        writer.WriteUInt32(Price);
        writer.WriteBoolean(IsLocked);
        writer.WriteInt16(WorldX);
        writer.WriteInt16(WorldY);
        writer.WriteInt16(ModelId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        OwnerId = reader.ReadInt32();
        OwnerName = reader.ReadUtf();
        Price = reader.ReadUInt32();
        IsLocked = reader.ReadBoolean();
        WorldX = reader.ReadInt16();
        WorldY = reader.ReadInt16();
        ModelId = reader.ReadInt16();
    }
}