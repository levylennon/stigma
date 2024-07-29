using Stigma.Protocol.Types.Game.Guild;

namespace Stigma.Protocol.Messages.Game.Guild;

public class GuildJoinedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5564;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string GuildName { get; set; }

    public required GuildEmblem GuildEmblemValue { get; set; }

    public required uint MemberRights { get; set; }

    public GuildJoinedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUtf(GuildName);
        GuildEmblemValue.Serialize(writer);
        writer.WriteUInt32(MemberRights);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        GuildName = reader.ReadUtf();
        GuildEmblemValue = new GuildEmblem();
        GuildEmblemValue.Deserialize(reader);
        MemberRights = reader.ReadUInt32();
    }
}