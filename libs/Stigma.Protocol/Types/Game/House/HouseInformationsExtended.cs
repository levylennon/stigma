using Stigma.Protocol.Types.Game.Guild;

namespace Stigma.Protocol.Types.Game.House;

public sealed class HouseInformationsExtended : HouseInformations
{
    public new const ushort ProtocolTypeId = 112;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public string GuildName { get; set; }

    public GuildEmblem GuildEmblemValue { get; set; }

    public HouseInformationsExtended()
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