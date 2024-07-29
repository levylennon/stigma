using Stigma.Protocol.Types.Game.Guild;

namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildInformationsMemberUpdateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5597;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required GuildMember Member { get; set; }

    public GuildInformationsMemberUpdateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        Member.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Member = new GuildMember();
        Member.Deserialize(reader);
    }
}