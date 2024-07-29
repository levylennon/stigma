namespace Stigma.Protocol.Messages.Game.Inventory;

public sealed class KamasUpdateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5537;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int KamasTotal { get; set; }

    public KamasUpdateMessage()
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