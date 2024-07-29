namespace Stigma.Protocol.Messages.Game.Subscriber;

public sealed class SubscriptionLimitationMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5542;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Reason { get; set; }

    public SubscriptionLimitationMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(Reason);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Reason = reader.ReadInt8();
    }
}