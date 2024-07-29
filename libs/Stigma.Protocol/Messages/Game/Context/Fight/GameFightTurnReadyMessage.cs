namespace Stigma.Protocol.Messages.Game.Context.Fight;

public sealed class GameFightTurnReadyMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 716;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool IsReady { get; set; }

    public GameFightTurnReadyMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(IsReady);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        IsReady = reader.ReadBoolean();
    }
}