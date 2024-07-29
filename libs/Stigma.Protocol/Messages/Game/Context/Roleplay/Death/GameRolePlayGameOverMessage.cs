namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Death;

public sealed class GameRolePlayGameOverMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 746;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public GameRolePlayGameOverMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}