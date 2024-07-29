namespace Stigma.Protocol.Messages.Game.Context.Notification;

public sealed class NotificationByServerMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6103;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required ushort Id { get; set; }

    public required IEnumerable<string> Parameters { get; set; }

    public NotificationByServerMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUInt16(Id);
        var parametersBefore = writer.Position;
        var parametersCount = 0;
        writer.WriteInt16(0);
        foreach (var item in Parameters)
        {
            writer.WriteUtf(item);
            parametersCount++;
        }

        var parametersAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, parametersBefore);
        writer.WriteInt16((short)parametersCount);
        writer.Seek(SeekOrigin.Begin, parametersAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Id = reader.ReadUInt16();
        var parametersCount = reader.ReadInt16();
        var parameters = new string[parametersCount];
        for (var i = 0; i < parametersCount; i++) parameters[i] = reader.ReadUtf();
        Parameters = parameters;
    }
}