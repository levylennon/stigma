namespace Stigma.Protocol.Messages.Game.Context.Fight;

public sealed class GameFightReadyMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 708;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool IsReady { get; set; }

    public GameFightReadyMessage()
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