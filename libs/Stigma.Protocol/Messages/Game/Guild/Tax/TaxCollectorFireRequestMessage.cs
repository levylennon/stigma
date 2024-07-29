namespace Stigma.Protocol.Messages.Game.Guild.Tax;

public sealed class TaxCollectorFireRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5682;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int CollectorId { get; set; }

    public TaxCollectorFireRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(CollectorId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        CollectorId = reader.ReadInt32();
    }
}