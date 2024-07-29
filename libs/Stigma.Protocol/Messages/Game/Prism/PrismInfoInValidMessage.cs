namespace Stigma.Protocol.Messages.Game.Prism;

public sealed class PrismInfoInValidMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5859;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Reason { get; set; }

    public PrismInfoInValidMessage()
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