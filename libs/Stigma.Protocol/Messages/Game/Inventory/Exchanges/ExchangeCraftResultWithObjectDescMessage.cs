using Stigma.Protocol.Types.Game.Data.Items;

namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeCraftResultWithObjectDescMessage : ExchangeCraftResultMessage
{
    public new const uint ProtocolMessageId = 5999;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required ObjectItemMinimalInformation ObjectInfo { get; set; }

    public ExchangeCraftResultWithObjectDescMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        ObjectInfo.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        ObjectInfo = new ObjectItemMinimalInformation();
        ObjectInfo.Deserialize(reader);
    }
}