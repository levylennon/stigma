namespace Stigma.Protocol.Messages.Game.Context;

public sealed class GameContextCreateErrorMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6024;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public GameContextCreateErrorMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}