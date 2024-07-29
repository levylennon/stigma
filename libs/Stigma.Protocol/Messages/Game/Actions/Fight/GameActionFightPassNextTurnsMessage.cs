namespace Stigma.Protocol.Messages.Game.Actions.Fight;

public sealed class GameActionFightPassNextTurnsMessage : AbstractGameActionMessage
{
    public new const uint ProtocolMessageId = 5529;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int TargetId { get; set; }

    public required sbyte TurnCount { get; set; }

    public GameActionFightPassNextTurnsMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(TargetId);
        writer.WriteInt8(TurnCount);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        TargetId = reader.ReadInt32();
        TurnCount = reader.ReadInt8();
    }
}