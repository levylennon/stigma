namespace Stigma.Protocol.Types.Game.Character.Characteristic;

public sealed class CharacterBaseCharacteristic : DofusType
{
    public new const ushort ProtocolTypeId = 4;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short Base { get; set; }

    public short ObjectsAndMountBonus { get; set; }

    public short AlignGiftBonus { get; set; }

    public short ContextModif { get; set; }

    public CharacterBaseCharacteristic()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(Base);
        writer.WriteInt16(ObjectsAndMountBonus);
        writer.WriteInt16(AlignGiftBonus);
        writer.WriteInt16(ContextModif);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Base = reader.ReadInt16();
        ObjectsAndMountBonus = reader.ReadInt16();
        AlignGiftBonus = reader.ReadInt16();
        ContextModif = reader.ReadInt16();
    }
}