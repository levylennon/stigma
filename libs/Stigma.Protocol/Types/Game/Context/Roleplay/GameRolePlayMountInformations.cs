namespace Stigma.Protocol.Types.Game.Context.Roleplay;

public sealed class GameRolePlayMountInformations : GameRolePlayNamedActorInformations
{
    public new const ushort ProtocolTypeId = 180;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public string OwnerName { get; set; }

    public byte Level { get; set; }

    public GameRolePlayMountInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUtf(OwnerName);
        writer.WriteUInt8(Level);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        OwnerName = reader.ReadUtf();
        Level = reader.ReadUInt8();
    }
}