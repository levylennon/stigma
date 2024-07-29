using Stigma.Protocol.Types.Game.Context.Roleplay.Party;

namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Party;

public sealed class PartyJoinMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5576;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int PartyLeaderId { get; set; }

    public required IEnumerable<PartyMemberInformations> Members { get; set; }

    public PartyJoinMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(PartyLeaderId);
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
        PartyLeaderId = reader.ReadInt32();
        var membersCount = reader.ReadInt16();
        var members = new PartyMemberInformations[membersCount];
        for (var i = 0; i < membersCount; i++)
        {
            var entry = new PartyMemberInformations();
            entry.Deserialize(reader);
            members[i] = entry;
        }

        Members = members;
    }
}