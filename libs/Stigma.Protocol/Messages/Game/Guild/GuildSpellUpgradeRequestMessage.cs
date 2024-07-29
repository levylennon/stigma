namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildSpellUpgradeRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5699;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int SpellId { get; set; }

    public GuildSpellUpgradeRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(SpellId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        SpellId = reader.ReadInt32();
    }
}