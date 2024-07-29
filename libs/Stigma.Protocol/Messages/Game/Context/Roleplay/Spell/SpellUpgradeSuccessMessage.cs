namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Spell;

public sealed class SpellUpgradeSuccessMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 1201;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int SpellId { get; set; }

    public required sbyte SpellLevel { get; set; }

    public SpellUpgradeSuccessMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(SpellId);
        writer.WriteInt8(SpellLevel);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        SpellId = reader.ReadInt32();
        SpellLevel = reader.ReadInt8();
    }
}