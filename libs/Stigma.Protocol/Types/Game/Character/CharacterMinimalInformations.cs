namespace Stigma.Protocol.Types.Game.Character;

public class CharacterMinimalInformations : DofusType
{
    public new const ushort ProtocolTypeId = 110;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int Id { get; set; }

    public string Name { get; set; }

    public byte Level { get; set; }

    public CharacterMinimalInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Id);
        writer.WriteUtf(Name);
        writer.WriteUInt8(Level);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Id = reader.ReadInt32();
        Name = reader.ReadUtf();
        Level = reader.ReadUInt8();
    }
}