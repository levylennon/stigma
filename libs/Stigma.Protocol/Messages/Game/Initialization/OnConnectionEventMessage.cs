namespace Stigma.Protocol.Messages.Game.Initialization;

public sealed class OnConnectionEventMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5726;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte EventType { get; set; }

    public OnConnectionEventMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(EventType);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        EventType = reader.ReadInt8();
    }
}