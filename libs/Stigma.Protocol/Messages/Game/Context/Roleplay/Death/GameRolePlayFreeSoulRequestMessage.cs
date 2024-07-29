namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Death;

public sealed class GameRolePlayFreeSoulRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 745;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public GameRolePlayFreeSoulRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}