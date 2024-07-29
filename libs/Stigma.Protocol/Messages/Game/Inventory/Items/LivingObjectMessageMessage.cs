namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public sealed class LivingObjectMessageMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6065;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short MsgId { get; set; }

    public required uint TimeStamp { get; set; }

    public required string Owner { get; set; }

    public required uint ObjectGenericId { get; set; }

    public LivingObjectMessageMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(MsgId);
        writer.WriteUInt32(TimeStamp);
        writer.WriteUtf(Owner);
        writer.WriteUInt32(ObjectGenericId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        MsgId = reader.ReadInt16();
        TimeStamp = reader.ReadUInt32();
        Owner = reader.ReadUtf();
        ObjectGenericId = reader.ReadUInt32();
    }
}