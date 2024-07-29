namespace Stigma.Protocol.Messages.Game.Context.Notification;

public sealed class NotificationUpdateFlagMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6090;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short Index { get; set; }

    public NotificationUpdateFlagMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(Index);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Index = reader.ReadInt16();
    }
}