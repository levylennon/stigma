using Stigma.Protocol.Types.Game.Data.Items.Effects;

namespace Stigma.Protocol.Types.Game.Data.Items;

public sealed class BidExchangerObjectInfo : DofusType
{
    public new const ushort ProtocolTypeId = 122;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int ObjectUID { get; set; }

    public IEnumerable<ObjectEffect> Effects { get; set; }

    public IEnumerable<int> Prices { get; set; }

    public BidExchangerObjectInfo()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(ObjectUID);
        var effectsBefore = writer.Position;
        var effectsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Effects)
        {
            writer.WriteUInt16(item.ProtocolId);
            item.Serialize(writer);
            effectsCount++;
        }

        var effectsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, effectsBefore);
        writer.WriteInt16((short)effectsCount);
        writer.Seek(SeekOrigin.Begin, effectsAfter);
        var pricesBefore = writer.Position;
        var pricesCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Prices)
        {
            writer.WriteInt32(item);
            pricesCount++;
        }

        var pricesAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, pricesBefore);
        writer.WriteInt16((short)pricesCount);
        writer.Seek(SeekOrigin.Begin, pricesAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ObjectUID = reader.ReadInt32();
        var effectsCount = reader.ReadInt16();
        var effects = new ObjectEffect[effectsCount];
        for (var i = 0; i < effectsCount; i++)
        {
            var entry = DofusTypeFactory.CreateInstance<ObjectEffect>(reader.ReadUInt16());
            entry.Deserialize(reader);
            effects[i] = entry;
        }

        Effects = effects;
        var pricesCount = reader.ReadInt16();
        var prices = new int[pricesCount];
        for (var i = 0; i < pricesCount; i++) prices[i] = reader.ReadInt32();
        Prices = prices;
    }
}