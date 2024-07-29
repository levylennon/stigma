namespace Stigma.Protocol.Messages.Game.Context.Mount;

public sealed class MountToggleRidingRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5976;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public MountToggleRidingRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}