using Stigma.Protocol.Types.Game.Context.Fight;

namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Fight;

public sealed class GameRolePlayShowChallengeMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 301;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required FightCommonInformations CommonsInfos { get; set; }

    public GameRolePlayShowChallengeMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        CommonsInfos.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        CommonsInfos = new FightCommonInformations();
        CommonsInfos.Deserialize(reader);
    }
}