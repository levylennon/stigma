using Stigma.Protocol.Types.Game.Data.Items;

namespace Stigma.Protocol.Types.Game.Startup;

public sealed class StartupActionAddObject : DofusType
{
    public new const ushort ProtocolTypeId = 52;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int Uid { get; set; }

    public string Title { get; set; }

    public string Text { get; set; }

    public string DescUrl { get; set; }

    public string PictureUrl { get; set; }

    public IEnumerable<ObjectItemMinimalInformation> Items { get; set; }

    public StartupActionAddObject()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Uid);
        writer.WriteUtf(Title);
        writer.WriteUtf(Text);
        writer.WriteUtf(DescUrl);
        writer.WriteUtf(PictureUrl);
        var itemsBefore = writer.Position;
        var itemsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Items)
        {
            item.Serialize(writer);
            itemsCount++;
        }

        var itemsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, itemsBefore);
        writer.WriteInt16((short)itemsCount);
        writer.Seek(SeekOrigin.Begin, itemsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Uid = reader.ReadInt32();
        Title = reader.ReadUtf();
        Text = reader.ReadUtf();
        DescUrl = reader.ReadUtf();
        PictureUrl = reader.ReadUtf();
        var itemsCount = reader.ReadInt16();
        var items = new ObjectItemMinimalInformation[itemsCount];
        for (var i = 0; i < itemsCount; i++)
        {
            var entry = new ObjectItemMinimalInformation();
            entry.Deserialize(reader);
            items[i] = entry;
        }

        Items = items;
    }
}