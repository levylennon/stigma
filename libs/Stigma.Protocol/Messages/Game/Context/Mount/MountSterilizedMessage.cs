namespace Stigma.Protocol.Messages.Game.Context.Mount;

public sealed class MountSterilizedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5977;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required double MountId { get; set; }

    public MountSterilizedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteDouble(MountId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        MountId = reader.ReadDouble();
    }
}