namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeCraftInformationObjectMessage : ExchangeCraftResultWithObjectIdMessage
{
    public new const uint ProtocolMessageId = 5794;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int PlayerId { get; set; }

    public ExchangeCraftInformationObjectMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(PlayerId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        PlayerId = reader.ReadInt32();
    }
}