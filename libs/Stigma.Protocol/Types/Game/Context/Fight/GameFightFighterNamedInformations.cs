namespace Stigma.Protocol.Types.Game.Context.Fight;

public class GameFightFighterNamedInformations : GameFightFighterInformations
{
    public new const ushort ProtocolTypeId = 158;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public string Name { get; set; }

    public GameFightFighterNamedInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUtf(Name);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Name = reader.ReadUtf();
    }
}