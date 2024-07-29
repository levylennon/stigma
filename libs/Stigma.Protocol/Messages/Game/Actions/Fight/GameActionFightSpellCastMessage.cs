namespace Stigma.Protocol.Messages.Game.Actions.Fight;

public sealed class GameActionFightSpellCastMessage : AbstractGameActionFightTargetedAbilityMessage
{
    public new const uint ProtocolMessageId = 1010;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short SpellId { get; set; }

    public required sbyte SpellLevel { get; set; }

    public GameActionFightSpellCastMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(SpellId);
        writer.WriteInt8(SpellLevel);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        SpellId = reader.ReadInt16();
        SpellLevel = reader.ReadInt8();
    }
}