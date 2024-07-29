using Stigma.Protocol.Types.Game.Context.Roleplay;

namespace Stigma.Protocol.Types.Game.Context;

public sealed class TaxCollectorStaticInformations : DofusType
{
    public new const ushort ProtocolTypeId = 147;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short FirstNameId { get; set; }

    public short LastNameId { get; set; }

    public GuildInformations GuildIdentity { get; set; }

    public TaxCollectorStaticInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(FirstNameId);
        writer.WriteInt16(LastNameId);
        GuildIdentity.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FirstNameId = reader.ReadInt16();
        LastNameId = reader.ReadInt16();
        GuildIdentity = new GuildInformations();
        GuildIdentity.Deserialize(reader);
    }
}