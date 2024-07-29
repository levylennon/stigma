namespace Stigma.Protocol.Messages.Game.Character.Creation;

public sealed class CharacterCreationRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 160;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string Name { get; set; }

    public required sbyte Breed { get; set; }

    public required bool Sex { get; set; }

    public required IEnumerable<int> Colors { get; set; }

    public CharacterCreationRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUtf(Name);
        writer.WriteInt8(Breed);
        writer.WriteBoolean(Sex);
        var colorsBefore = writer.Position;
        var colorsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Colors)
        {
            writer.WriteInt32(item);
            colorsCount++;
        }

        var colorsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, colorsBefore);
        writer.WriteInt16((short)colorsCount);
        writer.Seek(SeekOrigin.Begin, colorsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Name = reader.ReadUtf();
        Breed = reader.ReadInt8();
        Sex = reader.ReadBoolean();
        var colorsCount = reader.ReadInt16();
        var colors = new int[colorsCount];
        for (var i = 0; i < colorsCount; i++) colors[i] = reader.ReadInt32();
        Colors = colors;
    }
}