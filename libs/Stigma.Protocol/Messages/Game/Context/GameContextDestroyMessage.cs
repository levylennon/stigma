namespace Stigma.Protocol.Messages.Game.Context;

public sealed class GameContextDestroyMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 201;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public GameContextDestroyMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}