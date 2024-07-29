namespace Stigma.Protocol.Messages.Game.Pvp;

public sealed class PVPActivationCostMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 1801;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short Cost { get; set; }

    public PVPActivationCostMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(Cost);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Cost = reader.ReadInt16();
    }
}