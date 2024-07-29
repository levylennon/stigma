namespace Stigma.Protocol.Types.Game.Context.Fight;

public class FightResultFighterListEntry : FightResultListEntry
{
    public new const ushort ProtocolTypeId = 189;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int Id { get; set; }

    public bool Alive { get; set; }

    public FightResultFighterListEntry()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(Id);
        writer.WriteBoolean(Alive);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Id = reader.ReadInt32();
        Alive = reader.ReadBoolean();
    }
}