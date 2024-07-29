namespace Stigma.Protocol.Messages.Game.Basic;

public sealed class BasicDateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 177;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Day { get; set; }

    public required sbyte Month { get; set; }

    public required short Year { get; set; }

    public BasicDateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(Day);
        writer.WriteInt8(Month);
        writer.WriteInt16(Year);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Day = reader.ReadInt8();
        Month = reader.ReadInt8();
        Year = reader.ReadInt16();
    }
}