namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public sealed class ObjectMovementMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 3010;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int ObjectUID { get; set; }

    public required byte Position { get; set; }

    public ObjectMovementMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(ObjectUID);
        writer.WriteUInt8(Position);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ObjectUID = reader.ReadInt32();
        Position = reader.ReadUInt8();
    }
}