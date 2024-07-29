namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangePlayerRequestMessage : ExchangeRequestMessage
{
    public new const uint ProtocolMessageId = 5773;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Target { get; set; }

    public ExchangePlayerRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(Target);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Target = reader.ReadInt32();
    }
}