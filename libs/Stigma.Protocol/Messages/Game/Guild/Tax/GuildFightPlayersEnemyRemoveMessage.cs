namespace Stigma.Protocol.Messages.Game.Guild.Tax;

public sealed class GuildFightPlayersEnemyRemoveMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5929;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required double FightId { get; set; }

    public required int PlayerId { get; set; }

    public GuildFightPlayersEnemyRemoveMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteDouble(FightId);
        writer.WriteInt32(PlayerId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FightId = reader.ReadDouble();
        PlayerId = reader.ReadInt32();
    }
}