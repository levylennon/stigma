using Stigma.Protocol.Types.Game.Character.Alignment;

namespace Stigma.Protocol.Types.Game.Context.Roleplay;

public sealed class GameRolePlayPrismInformations : GameRolePlayActorInformations
{
    public new const ushort ProtocolTypeId = 161;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public ActorAlignmentInformations AlignInfos { get; set; }

    public GameRolePlayPrismInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        AlignInfos.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        AlignInfos = new ActorAlignmentInformations();
        AlignInfos.Deserialize(reader);
    }
}