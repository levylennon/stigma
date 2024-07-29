using Stigma.Protocol.Types.Game.Data.Items;

namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public sealed class ObjectAddedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 3025;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required ObjectItem Object { get; set; }

    public ObjectAddedMessage()
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