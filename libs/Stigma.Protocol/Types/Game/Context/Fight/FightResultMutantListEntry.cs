namespace Stigma.Protocol.Types.Game.Context.Fight;

public sealed class FightResultMutantListEntry : FightResultFighterListEntry
{
    public new const ushort ProtocolTypeId = 216;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public ushort Level { get; set; }

    public FightResultMutantListEntry()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUInt16(Level);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Level = reader.ReadUInt16();
    }
}