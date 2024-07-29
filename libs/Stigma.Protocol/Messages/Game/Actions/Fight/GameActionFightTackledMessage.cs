namespace Stigma.Protocol.Messages.Game.Actions.Fight;

public sealed class GameActionFightTackledMessage : AbstractGameActionMessage
{
    public new const uint ProtocolMessageId = 1004;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public GameActionFightTackledMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
    }
}