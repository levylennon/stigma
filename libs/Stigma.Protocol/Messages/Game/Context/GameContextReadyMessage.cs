namespace Stigma.Protocol.Messages.Game.Context;

public sealed class GameContextReadyMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6071;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public GameContextReadyMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}