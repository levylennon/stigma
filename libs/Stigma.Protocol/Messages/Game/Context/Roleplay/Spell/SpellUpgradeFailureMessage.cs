namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Spell;

public sealed class SpellUpgradeFailureMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 1202;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public SpellUpgradeFailureMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}