using Stigma.Protocol.Types.Game.Context.Roleplay;

namespace Stigma.Protocol.Types.Game.Context;

public sealed class GameRolePlayTaxCollectorInformations : GameRolePlayActorInformations
{
    public new const ushort ProtocolTypeId = 148;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short FirstNameId { get; set; }

    public short LastNameId { get; set; }

    public GuildInformations GuildIdentity { get; set; }

    public byte GuildLevel { get; set; }

    public GameRolePlayTaxCollectorInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(FirstNameId);
        writer.WriteInt16(LastNameId);
        GuildIdentity.Serialize(writer);
        writer.WriteUInt8(GuildLevel);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        FirstNameId = reader.ReadInt16();
        LastNameId = reader.ReadInt16();
        GuildIdentity = new GuildInformations();
        GuildIdentity.Deserialize(reader);
        GuildLevel = reader.ReadUInt8();
    }
}