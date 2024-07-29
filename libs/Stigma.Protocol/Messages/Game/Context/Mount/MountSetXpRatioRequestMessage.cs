namespace Stigma.Protocol.Messages.Game.Context.Mount;

public sealed class MountSetXpRatioRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5989;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte XpRatio { get; set; }

    public MountSetXpRatioRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(XpRatio);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        XpRatio = reader.ReadInt8();
    }
}