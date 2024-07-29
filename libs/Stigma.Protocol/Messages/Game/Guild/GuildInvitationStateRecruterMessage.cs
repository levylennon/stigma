namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildInvitationStateRecruterMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5563;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string RecrutedName { get; set; }

    public required sbyte InvitationState { get; set; }

    public GuildInvitationStateRecruterMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUtf(RecrutedName);
        writer.WriteInt8(InvitationState);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        RecrutedName = reader.ReadUtf();
        InvitationState = reader.ReadInt8();
    }
}