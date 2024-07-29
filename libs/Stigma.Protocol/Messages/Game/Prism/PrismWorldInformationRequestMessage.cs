namespace Stigma.Protocol.Messages.Game.Prism;

public sealed class PrismWorldInformationRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5985;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Join { get; set; }

    public PrismWorldInformationRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(Join);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Join = reader.ReadBoolean();
    }
}