namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public sealed class ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6021;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Allow { get; set; }

    public ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(Allow);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Allow = reader.ReadBoolean();
    }
}