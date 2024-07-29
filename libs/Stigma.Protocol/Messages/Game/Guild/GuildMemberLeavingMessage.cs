namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildMemberLeavingMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5923;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Kicked { get; set; }

    public required int MemberId { get; set; }

    public GuildMemberLeavingMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(Kicked);
        writer.WriteInt32(MemberId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Kicked = reader.ReadBoolean();
        MemberId = reader.ReadInt32();
    }
}