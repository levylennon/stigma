namespace Stigma.Protocol.Messages.Connection.Register;

public sealed class NicknameChoiceRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5639;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string Nickname { get; set; }

    public NicknameChoiceRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUtf(Nickname);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Nickname = reader.ReadUtf();
    }
}