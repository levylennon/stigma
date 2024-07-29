namespace Stigma.Protocol.Messages.Game.Actions;

public sealed class GameActionNoopMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 1002;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public GameActionNoopMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}