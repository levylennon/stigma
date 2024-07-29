namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Spell;

public sealed class SpellItemBoostMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6011;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int StatId { get; set; }

    public required short SpellId { get; set; }

    public required short Value { get; set; }

    public SpellItemBoostMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(StatId);
        writer.WriteInt16(SpellId);
        writer.WriteInt16(Value);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        StatId = reader.ReadInt32();
        SpellId = reader.ReadInt16();
        Value = reader.ReadInt16();
    }
}