namespace Stigma.Protocol.Messages.Game.Context.Mount;

public sealed class MountXpRatioMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5970;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Ratio { get; set; }

    public MountXpRatioMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(Ratio);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Ratio = reader.ReadInt8();
    }
}