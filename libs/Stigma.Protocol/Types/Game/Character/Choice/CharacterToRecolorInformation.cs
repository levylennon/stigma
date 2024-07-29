namespace Stigma.Protocol.Types.Game.Character.Choice;

public sealed class CharacterToRecolorInformation : DofusType
{
    public new const ushort ProtocolTypeId = 212;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int Id { get; set; }

    public IEnumerable<int> Colors { get; set; }

    public CharacterToRecolorInformation()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Id);
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
        Id = reader.ReadInt32();
        var colorsCount = reader.ReadInt16();
        var colors = new int[colorsCount];
        for (var i = 0; i < colorsCount; i++) colors[i] = reader.ReadInt32();
        Colors = colors;
    }
}