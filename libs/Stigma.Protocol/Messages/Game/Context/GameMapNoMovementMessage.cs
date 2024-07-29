namespace Stigma.Protocol.Messages.Game.Context;

public sealed class GameMapNoMovementMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 954;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public GameMapNoMovementMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}