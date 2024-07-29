using Stigma.Protocol.Types.Game.Interactive;

namespace Stigma.Protocol.Messages.Game.Interactive;

public sealed class InteractiveMapUpdateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5002;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<InteractiveElement> InteractiveElements { get; set; }

    public InteractiveMapUpdateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var interactiveElementsBefore = writer.Position;
        var interactiveElementsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in InteractiveElements)
        {
            item.Serialize(writer);
            interactiveElementsCount++;
        }

        var interactiveElementsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, interactiveElementsBefore);
        writer.WriteInt16((short)interactiveElementsCount);
        writer.Seek(SeekOrigin.Begin, interactiveElementsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var interactiveElementsCount = reader.ReadInt16();
        var interactiveElements = new InteractiveElement[interactiveElementsCount];
        for (var i = 0; i < interactiveElementsCount; i++)
        {
            var entry = new InteractiveElement();
            entry.Deserialize(reader);
            interactiveElements[i] = entry;
        }

        InteractiveElements = interactiveElements;
    }
}