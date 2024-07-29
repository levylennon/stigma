namespace Stigma.Protocol.Messages.Game.Actions.Fight;

public sealed class GameActionFightReduceDamagesMessage : AbstractGameActionMessage
{
    public new const uint ProtocolMessageId = 5526;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int TargetId { get; set; }

    public required int Amount { get; set; }

    public GameActionFightReduceDamagesMessage()
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