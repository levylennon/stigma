namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Visual;

public sealed class GameRolePlaySpellAnimMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6114;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int CasterId { get; set; }

    public required short TargetCellId { get; set; }

    public required short SpellId { get; set; }

    public required sbyte SpellLevel { get; set; }

    public GameRolePlaySpellAnimMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(CasterId);
        writer.WriteInt16(TargetCellId);
        writer.WriteInt16(SpellId);
        writer.WriteInt8(SpellLevel);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        CasterId = reader.ReadInt32();
        TargetCellId = reader.ReadInt16();
        SpellId = reader.ReadInt16();
        SpellLevel = reader.ReadInt8();
    }
}