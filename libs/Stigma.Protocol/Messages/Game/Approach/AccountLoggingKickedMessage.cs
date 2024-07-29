namespace Stigma.Protocol.Messages.Game.Approach;

public sealed class AccountLoggingKickedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6029;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Days { get; set; }

    public required int Hours { get; set; }

    public required int Minutes { get; set; }

    public AccountLoggingKickedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Days);
        writer.WriteInt32(Hours);
        writer.WriteInt32(Minutes);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Days = reader.ReadInt32();
        Hours = reader.ReadInt32();
        Minutes = reader.ReadInt32();
    }
}