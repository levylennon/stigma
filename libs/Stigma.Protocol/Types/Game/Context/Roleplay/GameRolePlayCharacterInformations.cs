using Stigma.Protocol.Types.Game.Character.Alignment;

namespace Stigma.Protocol.Types.Game.Context.Roleplay;

public sealed class GameRolePlayCharacterInformations : GameRolePlayHumanoidInformations
{
    public new const ushort ProtocolTypeId = 36;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public ActorAlignmentInformations AlignmentInfos { get; set; }

    public GameRolePlayCharacterInformations()
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