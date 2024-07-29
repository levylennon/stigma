using Stigma.Protocol.Types.Game.Guild;

namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Houses.Guild;

public sealed class HouseGuildRightsMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5703;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short HouseId { get; set; }

    public required string GuildName { get; set; }

    public required GuildEmblem GuildEmblemValue { get; set; }

    public required uint Rights { get; set; }

    public HouseGuildRightsMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(HouseId);
        writer.WriteUtf(GuildName);
        GuildEmblemValue.Serialize(writer);
        writer.WriteUInt32(Rights);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        HouseId = reader.ReadInt16();
        GuildName = reader.ReadUtf();
        GuildEmblemValue = new GuildEmblem();
        GuildEmblemValue.Deserialize(reader);
        Rights = reader.ReadUInt32();
    }
}