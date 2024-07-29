namespace Stigma.Protocol.Messages.Game.Context.Fight;

public sealed class GameFightJoinRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 701;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int FightId { get; set; }

    public required int FighterId { get; set; }

    public GameFightJoinRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(FightId);
        writer.WriteInt32(FighterId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FightId = reader.ReadInt32();
        FighterId = reader.ReadInt32();
    }
}