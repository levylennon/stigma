namespace Stigma.Protocol.Types.Game.Character;

public sealed class CharacterMinimalPlusLookAndGradeInformations : CharacterMinimalPlusLookInformations
{
    public new const ushort ProtocolTypeId = 193;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int Grade { get; set; }

    public CharacterMinimalPlusLookAndGradeInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(Grade);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Grade = reader.ReadInt32();
    }
}