namespace Stigma.Protocol.Messages.Game.Actions.Fight;

public sealed class GameActionFightReflectDamagesMessage : AbstractGameActionMessage
{
    public new const uint ProtocolMessageId = 5530;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int TargetId { get; set; }

    public required int Amount { get; set; }

    public GameActionFightReflectDamagesMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(TargetId);
        writer.WriteInt32(Amount);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        TargetId = reader.ReadInt32();
        Amount = reader.ReadInt32();
    }
}