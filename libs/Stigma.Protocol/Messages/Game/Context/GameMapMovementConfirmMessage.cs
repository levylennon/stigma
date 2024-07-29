namespace Stigma.Protocol.Messages.Game.Context;

public sealed class GameMapMovementConfirmMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 952;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public GameMapMovementConfirmMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}