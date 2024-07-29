using Stigma.Protocol.Types.Game.Guild;

namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildInformationsMembersMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5558;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<GuildMember> Members { get; set; }

    public GuildInformationsMembersMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var membersBefore = writer.Position;
        var membersCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Members)
        {
            item.Serialize(writer);
            membersCount++;
        }

        var membersAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, membersBefore);
        writer.WriteInt16((short)membersCount);
        writer.Seek(SeekOrigin.Begin, membersAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var membersCount = reader.ReadInt16();
        var members = new GuildMember[membersCount];
        for (var i = 0; i < membersCount; i++)
        {
            var entry = new GuildMember();
            entry.Deserialize(reader);
            members[i] = entry;
        }

        Members = members;
    }
}