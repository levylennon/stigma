namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildInvitedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5552;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int RecruterId { get; set; }

    public required string RecruterName { get; set; }

    public required string GuildName { get; set; }

    public GuildInvitedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(RecruterId);
        writer.WriteUtf(RecruterName);
        writer.WriteUtf(GuildName);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        RecruterId = reader.ReadInt32();
        RecruterName = reader.ReadUtf();
        GuildName = reader.ReadUtf();
    }
}