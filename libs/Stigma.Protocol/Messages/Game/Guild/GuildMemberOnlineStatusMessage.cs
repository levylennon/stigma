namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildMemberOnlineStatusMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6061;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int MemberId { get; set; }

    public required bool Online { get; set; }

    public GuildMemberOnlineStatusMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(MemberId);
        writer.WriteBoolean(Online);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        MemberId = reader.ReadInt32();
        Online = reader.ReadBoolean();
    }
}