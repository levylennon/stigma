namespace Stigma.Protocol.Types.Game.Friend;

public sealed class FriendOnlineInformations : FriendInformations
{
    public new const ushort ProtocolTypeId = 92;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public string PlayerName { get; set; }

    public short Level { get; set; }

    public sbyte AlignmentSide { get; set; }

    public sbyte Breed { get; set; }

    public bool Sex { get; set; }

    public string GuildName { get; set; }

    public FriendOnlineInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUtf(PlayerName);
        writer.WriteInt16(Level);
        writer.WriteInt8(AlignmentSide);
        writer.WriteInt8(Breed);
        writer.WriteBoolean(Sex);
        writer.WriteUtf(GuildName);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        PlayerName = reader.ReadUtf();
        Level = reader.ReadInt16();
        AlignmentSide = reader.ReadInt8();
        Breed = reader.ReadInt8();
        Sex = reader.ReadBoolean();
        GuildName = reader.ReadUtf();
    }
}