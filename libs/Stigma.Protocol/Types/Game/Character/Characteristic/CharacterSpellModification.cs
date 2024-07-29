namespace Stigma.Protocol.Types.Game.Character.Characteristic;

public sealed class CharacterSpellModification : DofusType
{
    public new const ushort ProtocolTypeId = 215;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public sbyte ModificationType { get; set; }

    public short SpellId { get; set; }

    public CharacterBaseCharacteristic Value { get; set; }

    public CharacterSpellModification()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(ModificationType);
        writer.WriteInt16(SpellId);
        Value.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ModificationType = reader.ReadInt8();
        SpellId = reader.ReadInt16();
        Value = new CharacterBaseCharacteristic();
        Value.Deserialize(reader);
    }
}