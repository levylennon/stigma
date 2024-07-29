namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeTypesExchangerDescriptionForUserMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5765;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<int> TypeDescription { get; set; }

    public ExchangeTypesExchangerDescriptionForUserMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var typeDescriptionBefore = writer.Position;
        var typeDescriptionCount = 0;
        writer.WriteInt16(0);
        foreach (var item in TypeDescription)
        {
            writer.WriteInt32(item);
            typeDescriptionCount++;
        }

        var typeDescriptionAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, typeDescriptionBefore);
        writer.WriteInt16((short)typeDescriptionCount);
        writer.Seek(SeekOrigin.Begin, typeDescriptionAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var typeDescriptionCount = reader.ReadInt16();
        var typeDescription = new int[typeDescriptionCount];
        for (var i = 0; i < typeDescriptionCount; i++) typeDescription[i] = reader.ReadInt32();
        TypeDescription = typeDescription;
    }
}