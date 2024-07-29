namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Spell;

public sealed class SpellForgetUIMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5565;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Open { get; set; }

    public SpellForgetUIMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(Open);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Open = reader.ReadBoolean();
    }
}