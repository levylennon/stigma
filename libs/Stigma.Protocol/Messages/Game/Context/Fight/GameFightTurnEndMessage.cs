namespace Stigma.Protocol.Messages.Game.Context.Fight;

public sealed class GameFightTurnEndMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 719;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Id { get; set; }

    public GameFightTurnEndMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Id);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Id = reader.ReadInt32();
    }
}