namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public class ObjectUseMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 3019;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int ObjectUID { get; set; }

    public ObjectUseMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(ObjectUID);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ObjectUID = reader.ReadInt32();
    }
}