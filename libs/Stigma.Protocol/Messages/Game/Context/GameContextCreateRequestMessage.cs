namespace Stigma.Protocol.Messages.Game.Context;

public sealed class GameContextCreateRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 250;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public GameContextCreateRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}