namespace Stigma.Protocol.Messages.Game.Actions.Fight;

public sealed class GameActionFightTriggerGlyphTrapMessage : AbstractGameActionMessage
{
    public new const uint ProtocolMessageId = 5741;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short MarkId { get; set; }

    public required int TriggeringCharacterId { get; set; }

    public required short TriggeredSpellId { get; set; }

    public GameActionFightTriggerGlyphTrapMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(MarkId);
        writer.WriteInt32(TriggeringCharacterId);
        writer.WriteInt16(TriggeredSpellId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        MarkId = reader.ReadInt16();
        TriggeringCharacterId = reader.ReadInt32();
        TriggeredSpellId = reader.ReadInt16();
    }
}