namespace Stigma.Protocol.Messages.Game.Context.Mount;

public sealed class MountReleaseRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5980;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public MountReleaseRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}