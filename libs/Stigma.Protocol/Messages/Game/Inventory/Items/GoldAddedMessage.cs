using Stigma.Protocol.Types.Game.Data.Items;

namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public sealed class GoldAddedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6030;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required GoldItem Gold { get; set; }

    public GoldAddedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        Gold.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Gold = new GoldItem();
        Gold.Deserialize(reader);
    }
}