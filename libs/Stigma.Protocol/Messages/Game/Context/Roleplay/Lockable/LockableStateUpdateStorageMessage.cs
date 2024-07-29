namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Lockable;

public sealed class LockableStateUpdateStorageMessage : LockableStateUpdateAbstractMessage
{
    public new const uint ProtocolMessageId = 5669;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int MapId { get; set; }

    public required int ElementId { get; set; }

    public LockableStateUpdateStorageMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(MapId);
        writer.WriteInt32(ElementId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        MapId = reader.ReadInt32();
        ElementId = reader.ReadInt32();
    }
}