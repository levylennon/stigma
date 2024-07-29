namespace Stigma.Protocol.Types.Game.Context.Fight;

public class FightResultListEntry : DofusType
{
    public new const ushort ProtocolTypeId = 16;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short Outcome { get; set; }

    public FightLoot Rewards { get; set; }

    public FightResultListEntry()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(Outcome);
        Rewards.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Outcome = reader.ReadInt16();
        Rewards = new FightLoot();
        Rewards.Deserialize(reader);
    }
}