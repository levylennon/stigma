namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildInvitationAnswerMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5556;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Accept { get; set; }

    public GuildInvitationAnswerMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(Accept);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Accept = reader.ReadBoolean();
    }
}