namespace Stigma.Protocol.Messages.Game.Character.Choice;

public sealed class CharacterSelectionWithRecolorMessage : CharacterSelectionMessage
{
    public new const uint ProtocolMessageId = 6075;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<int> IndexedColor { get; set; }

    public CharacterSelectionWithRecolorMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        var indexedColorBefore = writer.Position;
        var indexedColorCount = 0;
        writer.WriteInt16(0);
        foreach (var item in IndexedColor)
        {
            writer.WriteInt32(item);
            indexedColorCount++;
        }

        var indexedColorAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, indexedColorBefore);
        writer.WriteInt16((short)indexedColorCount);
        writer.Seek(SeekOrigin.Begin, indexedColorAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        var indexedColorCount = reader.ReadInt16();
        var indexedColor = new int[indexedColorCount];
        for (var i = 0; i < indexedColorCount; i++) indexedColor[i] = reader.ReadInt32();
        IndexedColor = indexedColor;
    }
}