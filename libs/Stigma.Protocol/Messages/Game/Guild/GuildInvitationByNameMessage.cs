namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildInvitationByNameMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6115;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string Name { get; set; }

    public GuildInvitationByNameMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUtf(Name);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Name = reader.ReadUtf();
    }
}