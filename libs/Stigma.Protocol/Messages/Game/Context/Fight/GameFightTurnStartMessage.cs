namespace Stigma.Protocol.Messages.Game.Context.Fight;

public sealed class GameFightTurnStartMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 714;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Id { get; set; }

    public required int WaitTime { get; set; }

    public GameFightTurnStartMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Id);
        writer.WriteInt32(WaitTime);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Id = reader.ReadInt32();
        WaitTime = reader.ReadInt32();
    }
}