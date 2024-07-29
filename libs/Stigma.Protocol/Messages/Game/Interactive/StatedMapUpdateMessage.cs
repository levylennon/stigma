using Stigma.Protocol.Types.Game.Interactive;

namespace Stigma.Protocol.Messages.Game.Interactive;

public sealed class StatedMapUpdateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5716;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<StatedElement> StatedElements { get; set; }

    public StatedMapUpdateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var statedElementsBefore = writer.Position;
        var statedElementsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in StatedElements)
        {
            item.Serialize(writer);
            statedElementsCount++;
        }

        var statedElementsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, statedElementsBefore);
        writer.WriteInt16((short)statedElementsCount);
        writer.Seek(SeekOrigin.Begin, statedElementsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var statedElementsCount = reader.ReadInt16();
        var statedElements = new StatedElement[statedElementsCount];
        for (var i = 0; i < statedElementsCount; i++)
        {
            var entry = new StatedElement();
            entry.Deserialize(reader);
            statedElements[i] = entry;
        }

        StatedElements = statedElements;
    }
}