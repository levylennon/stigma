namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public sealed class LivingObjectChangeSkinRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5725;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int LivingUID { get; set; }

    public required byte LivingPosition { get; set; }

    public required int SkinId { get; set; }

    public LivingObjectChangeSkinRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(LivingUID);
        writer.WriteUInt8(LivingPosition);
        writer.WriteInt32(SkinId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        LivingUID = reader.ReadInt32();
        LivingPosition = reader.ReadUInt8();
        SkinId = reader.ReadInt32();
    }
}