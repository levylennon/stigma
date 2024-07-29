namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Spell;

public sealed class ValidateSpellForgetMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 1700;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short SpellId { get; set; }

    public ValidateSpellForgetMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(SpellId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        SpellId = reader.ReadInt16();
    }
}