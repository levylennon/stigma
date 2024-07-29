namespace Stigma.Protocol.Messages.Game.Actions.Fight;

public sealed class GameActionFightInvisibleObstacleMessage : AbstractGameActionMessage
{
    public new const uint ProtocolMessageId = 5820;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int SourceSpellId { get; set; }

    public GameActionFightInvisibleObstacleMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(SourceSpellId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        SourceSpellId = reader.ReadInt32();
    }
}