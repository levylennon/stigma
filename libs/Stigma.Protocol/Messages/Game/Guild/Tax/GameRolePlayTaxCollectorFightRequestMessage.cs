namespace Stigma.Protocol.Messages.Game.Guild.Tax;

public sealed class GameRolePlayTaxCollectorFightRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5954;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int TaxCollectorId { get; set; }

    public GameRolePlayTaxCollectorFightRequestMessage()
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