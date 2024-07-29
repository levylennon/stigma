using Stigma.Protocol.Types.Game.Character.Alignment;

namespace Stigma.Protocol.Types.Game.Context.Fight;

public sealed class GameFightMonsterWithAlignmentInformations : GameFightMonsterInformations
{
    public new const ushort ProtocolTypeId = 203;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public ActorAlignmentInformations AlignmentInfos { get; set; }

    public GameFightMonsterWithAlignmentInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        AlignmentInfos.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        AlignmentInfos = new ActorAlignmentInformations();
        AlignmentInfos.Deserialize(reader);
    }
}