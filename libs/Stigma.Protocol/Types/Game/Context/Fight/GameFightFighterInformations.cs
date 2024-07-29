namespace Stigma.Protocol.Types.Game.Context.Fight;

public class GameFightFighterInformations : GameContextActorInformations
{
    public new const ushort ProtocolTypeId = 143;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public sbyte TeamId { get; set; }

    public bool Alive { get; set; }

    public GameFightMinimalStats Stats { get; set; }

    public GameFightFighterInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt8(TeamId);
        writer.WriteBoolean(Alive);
        Stats.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        TeamId = reader.ReadInt8();
        Alive = reader.ReadBoolean();
        Stats = new GameFightMinimalStats();
        Stats.Deserialize(reader);
    }
}