namespace Stigma.Protocol.Messages.Game.Prism;

public sealed class PrismFightSwapRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5901;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int TargetId { get; set; }

    public PrismFightSwapRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(TargetId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        TargetId = reader.ReadInt32();
    }
}