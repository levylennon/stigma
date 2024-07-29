using Stigma.Protocol.Types.Game.Guild;

namespace Stigma.Protocol.Types.Game.Paddock;

public sealed class PaddockPrivateInformations : PaddockAbandonnedInformations
{
    public new const ushort ProtocolTypeId = 131;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public string GuildName { get; set; }

    public GuildEmblem GuildEmblemValue { get; set; }

    public PaddockPrivateInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUtf(GuildName);
        GuildEmblemValue.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        GuildName = reader.ReadUtf();
        GuildEmblemValue = new GuildEmblem();
        GuildEmblemValue.Deserialize(reader);
    }
}