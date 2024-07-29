namespace Stigma.Protocol.Messages.Connection.Register;

public sealed class NicknameRefusedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5638;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Reason { get; set; }

    public NicknameRefusedMessage()
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