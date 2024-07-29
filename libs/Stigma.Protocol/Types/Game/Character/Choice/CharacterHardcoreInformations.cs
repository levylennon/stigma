namespace Stigma.Protocol.Types.Game.Character.Choice;

public sealed class CharacterHardcoreInformations : CharacterBaseInformations
{
    public new const ushort ProtocolTypeId = 86;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public sbyte DeathState { get; set; }

    public short DeathCount { get; set; }

    public byte DeathMaxLevel { get; set; }

    public CharacterHardcoreInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt8(DeathState);
        writer.WriteInt16(DeathCount);
        writer.WriteUInt8(DeathMaxLevel);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        DeathState = reader.ReadInt8();
        DeathCount = reader.ReadInt16();
        DeathMaxLevel = reader.ReadUInt8();
    }
}