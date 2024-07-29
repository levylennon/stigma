namespace Stigma.Protocol.Types.Game.Friend;

public sealed class FriendSpouseOnlineInformations : FriendSpouseInformations
{
    public new const ushort ProtocolTypeId = 93;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public bool InFight { get; set; }

    public bool FollowSpouse { get; set; }

    public bool PvpEnabled { get; set; }

    public int MapId { get; set; }

    public short SubAreaId { get; set; }

    public string GuildName { get; set; }

    public sbyte AlignmentSide { get; set; }

    public FriendSpouseOnlineInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, InFight);
        flag = BooleanByteWrapper.SetFlag(flag, 1, FollowSpouse);
        flag = BooleanByteWrapper.SetFlag(flag, 2, PvpEnabled);
        writer.WriteUInt8(flag);
        writer.WriteInt32(MapId);
        writer.WriteInt16(SubAreaId);
        writer.WriteUtf(GuildName);
        writer.WriteInt8(AlignmentSide);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        var flag = reader.ReadUInt8();
        InFight = BooleanByteWrapper.GetFlag(flag, 0);
        FollowSpouse = BooleanByteWrapper.GetFlag(flag, 1);
        PvpEnabled = BooleanByteWrapper.GetFlag(flag, 2);
        MapId = reader.ReadInt32();
        SubAreaId = reader.ReadInt16();
        GuildName = reader.ReadUtf();
        AlignmentSide = reader.ReadInt8();
    }
}