namespace Stigma.Protocol.Types.Game.Data.Items;

public sealed class SellerBuyerDescriptor : DofusType
{
    public new const ushort ProtocolTypeId = 121;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public IEnumerable<int> Quantities { get; set; }

    public IEnumerable<int> Types { get; set; }

    public float TaxPercentage { get; set; }

    public int MaxItemLevel { get; set; }

    public int MaxItemPerAccount { get; set; }

    public int NpcContextualId { get; set; }

    public short UnsoldDelay { get; set; }

    public SellerBuyerDescriptor()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var quantitiesBefore = writer.Position;
        var quantitiesCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Quantities)
        {
            writer.WriteInt32(item);
            quantitiesCount++;
        }

        var quantitiesAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, quantitiesBefore);
        writer.WriteInt16((short)quantitiesCount);
        writer.Seek(SeekOrigin.Begin, quantitiesAfter);
        var typesBefore = writer.Position;
        var typesCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Types)
        {
            writer.WriteInt32(item);
            typesCount++;
        }

        var typesAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, typesBefore);
        writer.WriteInt16((short)typesCount);
        writer.Seek(SeekOrigin.Begin, typesAfter);
        writer.WriteFloat(TaxPercentage);
        writer.WriteInt32(MaxItemLevel);
        writer.WriteInt32(MaxItemPerAccount);
        writer.WriteInt32(NpcContextualId);
        writer.WriteInt16(UnsoldDelay);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var quantitiesCount = reader.ReadInt16();
        var quantities = new int[quantitiesCount];
        for (var i = 0; i < quantitiesCount; i++) quantities[i] = reader.ReadInt32();
        Quantities = quantities;
        var typesCount = reader.ReadInt16();
        var types = new int[typesCount];
        for (var i = 0; i < typesCount; i++) types[i] = reader.ReadInt32();
        Types = types;
        TaxPercentage = reader.ReadFloat();
        MaxItemLevel = reader.ReadInt32();
        MaxItemPerAccount = reader.ReadInt32();
        NpcContextualId = reader.ReadInt32();
        UnsoldDelay = reader.ReadInt16();
    }
}