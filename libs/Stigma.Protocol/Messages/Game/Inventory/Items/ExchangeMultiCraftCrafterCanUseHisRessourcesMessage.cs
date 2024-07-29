namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public sealed class ExchangeMultiCraftCrafterCanUseHisRessourcesMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6020;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Allowed { get; set; }

    public ExchangeMultiCraftCrafterCanUseHisRessourcesMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(Allowed);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Allowed = reader.ReadBoolean();
    }
}