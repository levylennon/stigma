namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeObjectTransfertListToInvMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6039;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<int> Ids { get; set; }

    public ExchangeObjectTransfertListToInvMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var idsBefore = writer.Position;
        var idsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Ids)
        {
            writer.WriteInt32(item);
            idsCount++;
        }

        var idsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, idsBefore);
        writer.WriteInt16((short)idsCount);
        writer.Seek(SeekOrigin.Begin, idsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var idsCount = reader.ReadInt16();
        var ids = new int[idsCount];
        for (var i = 0; i < idsCount; i++) ids[i] = reader.ReadInt32();
        Ids = ids;
    }
}