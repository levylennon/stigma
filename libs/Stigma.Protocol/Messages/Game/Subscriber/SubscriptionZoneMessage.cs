namespace Stigma.Protocol.Messages.Game.Subscriber;

public sealed class SubscriptionZoneMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5573;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Active { get; set; }

    public SubscriptionZoneMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(Active);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Active = reader.ReadBoolean();
    }
}