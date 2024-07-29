namespace Stigma.Protocol.Types.Game.Data.Items.Effects;

public sealed class ObjectEffectLadder : ObjectEffectCreature
{
    public new const ushort ProtocolTypeId = 81;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int MonsterCount { get; set; }

    public ObjectEffectLadder()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(MonsterCount);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        MonsterCount = reader.ReadInt32();
    }
}