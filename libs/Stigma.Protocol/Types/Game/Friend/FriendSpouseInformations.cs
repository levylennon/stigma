using Stigma.Protocol.Types.Game.Look;

namespace Stigma.Protocol.Types.Game.Friend;

public class FriendSpouseInformations : DofusType
{
    public new const ushort ProtocolTypeId = 77;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int SpouseId { get; set; }

    public string SpouseName { get; set; }

    public byte SpouseLevel { get; set; }

    public sbyte Breed { get; set; }

    public sbyte Sex { get; set; }

    public EntityLook SpouseEntityLook { get; set; }

    public FriendSpouseInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(SpouseId);
        writer.WriteUtf(SpouseName);
        writer.WriteUInt8(SpouseLevel);
        writer.WriteInt8(Breed);
        writer.WriteInt8(Sex);
        SpouseEntityLook.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        SpouseId = reader.ReadInt32();
        SpouseName = reader.ReadUtf();
        SpouseLevel = reader.ReadUInt8();
        Breed = reader.ReadInt8();
        Sex = reader.ReadInt8();
        SpouseEntityLook = new EntityLook();
        SpouseEntityLook.Deserialize(reader);
    }
}