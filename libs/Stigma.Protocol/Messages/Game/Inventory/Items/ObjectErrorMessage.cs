namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public sealed class ObjectErrorMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 3004;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Reason { get; set; }

    public ObjectErrorMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(Reason);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Reason = reader.ReadInt8();
    }
}