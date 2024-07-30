namespace Stigma.Protocol.Messages.Game.Actions.Fight;

public sealed class GameActionFightDodgePointLossMessage : AbstractGameActionMessage
{
    public new const uint ProtocolMessageId = 5828;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int TargetId { get; set; }

    public required short Amount { get; set; }

    public GameActionFightDodgePointLossMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(TargetId);
        writer.WriteInt16(Amount);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        TargetId = reader.ReadInt32();
        Amount = reader.ReadInt16();
    }
}