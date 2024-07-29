namespace Stigma.Protocol.Messages.Game.Context.Fight;

public sealed class GameFightTurnFinishMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 718;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public GameFightTurnFinishMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}