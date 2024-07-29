namespace Stigma.Protocol.Messages.Connection;

public sealed class SelectedServerDataMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 42;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short ServerId { get; set; }

    public required string Address { get; set; }

    public required ushort Port { get; set; }

    public required bool CanCreateNewCharacter { get; set; }

    public required string Ticket { get; set; }

    public SelectedServerDataMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(ServerId);
        writer.WriteUtf(Address);
        writer.WriteUInt16(Port);
        writer.WriteBoolean(CanCreateNewCharacter);
        writer.WriteUtf(Ticket);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ServerId = reader.ReadInt16();
        Address = reader.ReadUtf();
        Port = reader.ReadUInt16();
        CanCreateNewCharacter = reader.ReadBoolean();
        Ticket = reader.ReadUtf();
    }
}