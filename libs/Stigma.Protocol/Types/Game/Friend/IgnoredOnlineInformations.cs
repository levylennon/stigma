namespace Stigma.Protocol.Types.Game.Friend;

public sealed class IgnoredOnlineInformations : IgnoredInformations
{
    public new const ushort ProtocolTypeId = 105;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public string PlayerName { get; set; }

    public sbyte Breed { get; set; }

    public bool Sex { get; set; }

    public IgnoredOnlineInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUtf(PlayerName);
        writer.WriteInt8(Breed);
        writer.WriteBoolean(Sex);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        PlayerName = reader.ReadUtf();
        Breed = reader.ReadInt8();
        Sex = reader.ReadBoolean();
    }
}