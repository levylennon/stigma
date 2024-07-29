namespace Stigma.Protocol.Messages.Game.Context;

public sealed class GameContextQuitMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 255;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public GameContextQuitMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}