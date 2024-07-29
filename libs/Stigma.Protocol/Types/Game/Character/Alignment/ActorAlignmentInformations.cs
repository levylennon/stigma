namespace Stigma.Protocol.Types.Game.Character.Alignment;

public class ActorAlignmentInformations : DofusType
{
    public new const ushort ProtocolTypeId = 201;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public sbyte AlignmentSide { get; set; }

    public sbyte AlignmentValue { get; set; }

    public sbyte AlignmentGrade { get; set; }

    public int CharacterPower { get; set; }

    public ActorAlignmentInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(AlignmentSide);
        writer.WriteInt8(AlignmentValue);
        writer.WriteInt8(AlignmentGrade);
        writer.WriteInt32(CharacterPower);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        AlignmentSide = reader.ReadInt8();
        AlignmentValue = reader.ReadInt8();
        AlignmentGrade = reader.ReadInt8();
        CharacterPower = reader.ReadInt32();
    }
}