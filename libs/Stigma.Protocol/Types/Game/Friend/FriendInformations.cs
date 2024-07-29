namespace Stigma.Protocol.Types.Game.Friend;

public class FriendInformations : DofusType
{
    public new const ushort ProtocolTypeId = 78;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public string Name { get; set; }

    public sbyte PlayerState { get; set; }

    public int LastConnection { get; set; }

    public FriendInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUtf(Name);
        writer.WriteInt8(PlayerState);
        writer.WriteInt32(LastConnection);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Name = reader.ReadUtf();
        PlayerState = reader.ReadInt8();
        LastConnection = reader.ReadInt32();
    }
}