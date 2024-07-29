namespace Stigma.Protocol.Messages.Game.Context.Mount;

public sealed class MountRenamedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5983;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required double MountId { get; set; }

    public required string Name { get; set; }

    public MountRenamedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteDouble(MountId);
        writer.WriteUtf(Name);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        MountId = reader.ReadDouble();
        Name = reader.ReadUtf();
    }
}