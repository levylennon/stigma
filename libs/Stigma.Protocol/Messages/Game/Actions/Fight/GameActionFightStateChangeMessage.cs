namespace Stigma.Protocol.Messages.Game.Actions.Fight;

public sealed class GameActionFightStateChangeMessage : AbstractGameActionMessage
{
    public new const uint ProtocolMessageId = 5569;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int TargetId { get; set; }

    public required short StateId { get; set; }

    public required bool Active { get; set; }

    public GameActionFightStateChangeMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(TargetId);
        writer.WriteInt16(StateId);
        writer.WriteBoolean(Active);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        TargetId = reader.ReadInt32();
        StateId = reader.ReadInt16();
        Active = reader.ReadBoolean();
    }
}