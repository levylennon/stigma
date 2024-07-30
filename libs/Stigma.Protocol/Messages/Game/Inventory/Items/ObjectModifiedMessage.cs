using Stigma.Protocol.Types.Game.Data.Items;

namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public sealed class ObjectModifiedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 3029;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required ObjectItem Object { get; set; }

    public ObjectModifiedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        Object.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Object = new ObjectItem();
        Object.Deserialize(reader);
    }
}