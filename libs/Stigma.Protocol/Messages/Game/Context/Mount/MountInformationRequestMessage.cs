namespace Stigma.Protocol.Messages.Game.Context.Mount;

public sealed class MountInformationRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5972;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required double Id { get; set; }

    public required double Time { get; set; }

    public MountInformationRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteDouble(Id);
        writer.WriteDouble(Time);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Id = reader.ReadDouble();
        Time = reader.ReadDouble();
    }
}