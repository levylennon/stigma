namespace Stigma.Protocol.Messages.Game.Guild.Tax;

public sealed class TaxCollectorErrorMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5634;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Reason { get; set; }

    public TaxCollectorErrorMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(Reason);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Reason = reader.ReadInt8();
    }
}