namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public sealed class LivingObjectDissociateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5723;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int LivingUID { get; set; }

    public required byte LivingPosition { get; set; }

    public LivingObjectDissociateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(LivingUID);
        writer.WriteUInt8(LivingPosition);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        LivingUID = reader.ReadInt32();
        LivingPosition = reader.ReadUInt8();
    }
}