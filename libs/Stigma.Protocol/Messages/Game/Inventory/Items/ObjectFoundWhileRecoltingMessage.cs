namespace Stigma.Protocol.Messages.Game.Inventory.Items;

public sealed class ObjectFoundWhileRecoltingMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6017;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int GenericId { get; set; }

    public required int Quantity { get; set; }

    public required int RessourceGenericId { get; set; }

    public ObjectFoundWhileRecoltingMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(GenericId);
        writer.WriteInt32(Quantity);
        writer.WriteInt32(RessourceGenericId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        GenericId = reader.ReadInt32();
        Quantity = reader.ReadInt32();
        RessourceGenericId = reader.ReadInt32();
    }
}