namespace Stigma.Protocol.Messages.Game.Inventory.Storage;

public sealed class StorageKamasUpdateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5645;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int KamasTotal { get; set; }

    public StorageKamasUpdateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(KamasTotal);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        KamasTotal = reader.ReadInt32();
    }
}