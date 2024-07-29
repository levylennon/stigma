namespace Stigma.Protocol.Messages.Game.Context;

public sealed class GameEntityDispositionErrorMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5695;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public GameEntityDispositionErrorMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}