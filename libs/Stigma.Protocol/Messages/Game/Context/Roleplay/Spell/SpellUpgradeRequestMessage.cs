namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Spell;

public sealed class SpellUpgradeRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5608;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short SpellId { get; set; }

    public SpellUpgradeRequestMessage()
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