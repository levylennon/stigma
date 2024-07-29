using Stigma.Protocol.Types.Game.Paddock;

namespace Stigma.Protocol.Messages.Game.Context.Mount;

public sealed class GameDataPaddockObjectListAddMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5992;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<PaddockItem> PaddockItemDescription { get; set; }

    public GameDataPaddockObjectListAddMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var paddockItemDescriptionBefore = writer.Position;
        var paddockItemDescriptionCount = 0;
        writer.WriteInt16(0);
        foreach (var item in PaddockItemDescription)
        {
            item.Serialize(writer);
            paddockItemDescriptionCount++;
        }

        var paddockItemDescriptionAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, paddockItemDescriptionBefore);
        writer.WriteInt16((short)paddockItemDescriptionCount);
        writer.Seek(SeekOrigin.Begin, paddockItemDescriptionAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var paddockItemDescriptionCount = reader.ReadInt16();
        var paddockItemDescription = new PaddockItem[paddockItemDescriptionCount];
        for (var i = 0; i < paddockItemDescriptionCount; i++)
        {
            var entry = new PaddockItem();
            entry.Deserialize(reader);
            paddockItemDescription[i] = entry;
        }

        PaddockItemDescription = paddockItemDescription;
    }
}