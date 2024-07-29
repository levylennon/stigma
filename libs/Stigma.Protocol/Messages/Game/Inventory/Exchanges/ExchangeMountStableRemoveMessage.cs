namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeMountStableRemoveMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5964;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required double MountId { get; set; }

    public ExchangeMountStableRemoveMessage()
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