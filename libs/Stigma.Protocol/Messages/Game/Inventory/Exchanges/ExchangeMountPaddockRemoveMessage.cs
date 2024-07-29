namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeMountPaddockRemoveMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6050;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required double MountId { get; set; }

    public ExchangeMountPaddockRemoveMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteDouble(MountId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        MountId = reader.ReadDouble();
    }
}