namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeOkMultiCraftMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5768;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int InitiatorId { get; set; }

    public required int OtherId { get; set; }

    public required sbyte Role { get; set; }

    public ExchangeOkMultiCraftMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(InitiatorId);
        writer.WriteInt32(OtherId);
        writer.WriteInt8(Role);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        InitiatorId = reader.ReadInt32();
        OtherId = reader.ReadInt32();
        Role = reader.ReadInt8();
    }
}