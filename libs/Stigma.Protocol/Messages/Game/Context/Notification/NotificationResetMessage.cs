namespace Stigma.Protocol.Messages.Game.Context.Notification;

public sealed class NotificationResetMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6089;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public NotificationResetMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}