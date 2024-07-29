namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public sealed class ObjectJobAddedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6014;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte JobId { get; set; }

    public ObjectJobAddedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(JobId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        JobId = reader.ReadInt8();
    }
}