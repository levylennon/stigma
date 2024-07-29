using Stigma.Protocol.Types.Game.Look;

namespace Stigma.Protocol.Messages.Game.Social;

public sealed class ContactLookMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5934;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int RequestId { get; set; }

    public required string PlayerName { get; set; }

    public required int PlayerId { get; set; }

    public required EntityLook Look { get; set; }

    public ContactLookMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(RequestId);
        writer.WriteUtf(PlayerName);
        writer.WriteInt32(PlayerId);
        Look.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        RequestId = reader.ReadInt32();
        PlayerName = reader.ReadUtf();
        PlayerId = reader.ReadInt32();
        Look = new EntityLook();
        Look.Deserialize(reader);
    }
}