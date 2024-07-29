namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildMembershipMessage : GuildJoinedMessage
{
    public new const uint ProtocolMessageId = 5835;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public GuildMembershipMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
    }
}