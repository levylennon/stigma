using Stigma.Protocol.Types.Game.Guild;

namespace Stigma.Protocol.Types.Game.Context.Roleplay;

public sealed class GuildInformations : DofusType
{
    public new const ushort ProtocolTypeId = 127;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public string GuildName { get; set; }

    public GuildEmblem GuildEmblemValue { get; set; }

    public GuildInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUtf(GuildName);
        GuildEmblemValue.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        GuildName = reader.ReadUtf();
        GuildEmblemValue = new GuildEmblem();
        GuildEmblemValue.Deserialize(reader);
    }
}