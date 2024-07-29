namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public sealed class ObjectUseOnCellMessage : ObjectUseMessage
{
    public new const uint ProtocolMessageId = 3013;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short Cells { get; set; }

    public ObjectUseOnCellMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(Cells);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Cells = reader.ReadInt16();
    }
}