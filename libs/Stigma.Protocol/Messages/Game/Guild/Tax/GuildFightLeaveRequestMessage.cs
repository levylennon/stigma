namespace Stigma.Protocol.Messages.Game.Guild.Tax;

public sealed class GuildFightLeaveRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5715;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int TaxCollectorId { get; set; }

    public required int CharacterId { get; set; }

    public GuildFightLeaveRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(TaxCollectorId);
        writer.WriteInt32(CharacterId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        TaxCollectorId = reader.ReadInt32();
        CharacterId = reader.ReadInt32();
    }
}