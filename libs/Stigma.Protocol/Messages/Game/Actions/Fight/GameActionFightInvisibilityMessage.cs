namespace Stigma.Protocol.Messages.Game.Actions.Fight;

public sealed class GameActionFightInvisibilityMessage : AbstractGameActionMessage
{
    public new const uint ProtocolMessageId = 5821;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int TargetId { get; set; }

    public required sbyte State { get; set; }

    public GameActionFightInvisibilityMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(TargetId);
        writer.WriteInt8(State);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        TargetId = reader.ReadInt32();
        State = reader.ReadInt8();
    }
}