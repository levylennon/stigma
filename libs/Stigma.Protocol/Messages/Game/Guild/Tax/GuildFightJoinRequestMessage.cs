namespace Stigma.Protocol.Messages.Game.Guild.Tax;

public sealed class GuildFightJoinRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5717;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int TaxCollectorId { get; set; }

    public GuildFightJoinRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(TaxCollectorId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        TaxCollectorId = reader.ReadInt32();
    }
}