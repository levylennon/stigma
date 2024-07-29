namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildInvitationStateRecrutedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5548;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte InvitationState { get; set; }

    public GuildInvitationStateRecrutedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(InvitationState);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        InvitationState = reader.ReadInt8();
    }
}