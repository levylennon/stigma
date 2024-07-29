namespace Stigma.Protocol.Messages.Handshake;

public sealed class ProtocolRequired : DofusMessage
{
    public new const uint ProtocolMessageId = 1;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public int RequiredVersion { get; set; }

    public int CurrentVersion { get; set; }

    public ProtocolRequired()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(RequiredVersion);
        writer.WriteInt32(CurrentVersion);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        RequiredVersion = reader.ReadInt32();
        CurrentVersion = reader.ReadInt32();
    }
}