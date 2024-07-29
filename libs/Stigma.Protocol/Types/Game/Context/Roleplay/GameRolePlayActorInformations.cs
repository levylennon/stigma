namespace Stigma.Protocol.Types.Game.Context.Roleplay;

public class GameRolePlayActorInformations : GameContextActorInformations
{
    public new const ushort ProtocolTypeId = 141;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public GameRolePlayActorInformations()
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