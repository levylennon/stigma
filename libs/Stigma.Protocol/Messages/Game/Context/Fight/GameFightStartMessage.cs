namespace Stigma.Protocol.Messages.Game.Context.Fight;

public sealed class GameFightStartMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 712;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public GameFightStartMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}