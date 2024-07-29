namespace Stigma.Protocol.Types.Game.Context.Fight;

public sealed class GameFightSpellCooldown : DofusType
{
    public new const ushort ProtocolTypeId = 205;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int SpellId { get; set; }

    public sbyte Cooldown { get; set; }

    public GameFightSpellCooldown()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(SpellId);
        writer.WriteInt8(Cooldown);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        SpellId = reader.ReadInt32();
        Cooldown = reader.ReadInt8();
    }
}