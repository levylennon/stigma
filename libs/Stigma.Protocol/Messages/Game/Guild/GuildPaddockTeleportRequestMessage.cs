namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildPaddockTeleportRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5957;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int PaddockId { get; set; }

    public GuildPaddockTeleportRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(PaddockId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        PaddockId = reader.ReadInt32();
    }
}