namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Lockable;

public sealed class LockableStateUpdateHouseDoorMessage : LockableStateUpdateAbstractMessage
{
    public new const uint ProtocolMessageId = 5668;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int HouseId { get; set; }

    public LockableStateUpdateHouseDoorMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(HouseId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        HouseId = reader.ReadInt32();
    }
}