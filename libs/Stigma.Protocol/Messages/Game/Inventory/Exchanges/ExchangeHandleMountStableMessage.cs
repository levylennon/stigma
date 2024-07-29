namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeHandleMountStableMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5965;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte ActionType { get; set; }

    public required int RideId { get; set; }

    public ExchangeHandleMountStableMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(ActionType);
        writer.WriteInt32(RideId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ActionType = reader.ReadInt8();
        RideId = reader.ReadInt32();
    }
}