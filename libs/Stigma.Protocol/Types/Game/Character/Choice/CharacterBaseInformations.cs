namespace Stigma.Protocol.Types.Game.Character.Choice;

public class CharacterBaseInformations : CharacterMinimalPlusLookInformations
{
    public new const ushort ProtocolTypeId = 45;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public sbyte Breed { get; set; }

    public bool Sex { get; set; }

    public CharacterBaseInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt8(Breed);
        writer.WriteBoolean(Sex);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Breed = reader.ReadInt8();
        Sex = reader.ReadBoolean();
    }
}