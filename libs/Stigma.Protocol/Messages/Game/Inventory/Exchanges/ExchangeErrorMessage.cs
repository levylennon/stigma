namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeErrorMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5513;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte ErrorType { get; set; }

    public ExchangeErrorMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(ErrorType);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ErrorType = reader.ReadInt8();
    }
}