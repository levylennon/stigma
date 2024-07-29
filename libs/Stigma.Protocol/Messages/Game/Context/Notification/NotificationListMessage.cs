namespace Stigma.Protocol.Messages.Game.Context.Notification;

public sealed class NotificationListMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6087;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<int> Flags { get; set; }

    public NotificationListMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var flagsBefore = writer.Position;
        var flagsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Flags)
        {
            writer.WriteInt32(item);
            flagsCount++;
        }

        var flagsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, flagsBefore);
        writer.WriteInt16((short)flagsCount);
        writer.Seek(SeekOrigin.Begin, flagsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var flagsCount = reader.ReadInt16();
        var flags = new int[flagsCount];
        for (var i = 0; i < flagsCount; i++) flags[i] = reader.ReadInt32();
        Flags = flags;
    }
}