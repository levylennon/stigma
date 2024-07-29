namespace Stigma.Protocol.Messages.Game.Context.Mount;

public sealed class MountRenameRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5987;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string Name { get; set; }

    public required double MountId { get; set; }

    public MountRenameRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUtf(Name);
        writer.WriteDouble(MountId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Name = reader.ReadUtf();
        MountId = reader.ReadDouble();
    }
}