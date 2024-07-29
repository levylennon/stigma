namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public class ExchangeCraftResultMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5790;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte CraftResult { get; set; }

    public ExchangeCraftResultMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(CraftResult);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        CraftResult = reader.ReadInt8();
    }
}