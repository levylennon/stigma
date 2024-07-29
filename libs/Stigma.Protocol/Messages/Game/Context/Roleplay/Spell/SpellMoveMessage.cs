namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Spell;

public sealed class SpellMoveMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5567;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short SpellId { get; set; }

    public required byte Position { get; set; }

    public SpellMoveMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(SpellId);
        writer.WriteUInt8(Position);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        SpellId = reader.ReadInt16();
        Position = reader.ReadUInt8();
    }
}