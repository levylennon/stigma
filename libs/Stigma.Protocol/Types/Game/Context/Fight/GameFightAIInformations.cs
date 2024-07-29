namespace Stigma.Protocol.Types.Game.Context.Fight;

public class GameFightAIInformations : GameFightFighterInformations
{
    public new const ushort ProtocolTypeId = 151;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public GameFightAIInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
    }
}