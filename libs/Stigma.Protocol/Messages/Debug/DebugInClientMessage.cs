namespace Stigma.Protocol.Messages.Debug;

public sealed class DebugInClientMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6028;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Level { get; set; }

    public required string Message { get; set; }

    public DebugInClientMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(Level);
        writer.WriteUtf(Message);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Level = reader.ReadInt8();
        Message = reader.ReadUtf();
    }
}