namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildKickRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5887;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int KickedId { get; set; }

    public GuildKickRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(KickedId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        KickedId = reader.ReadInt32();
    }
}