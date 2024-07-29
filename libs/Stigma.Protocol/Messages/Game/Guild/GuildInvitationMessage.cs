namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildInvitationMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5551;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int TargetId { get; set; }

    public GuildInvitationMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(TargetId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        TargetId = reader.ReadInt32();
    }
}