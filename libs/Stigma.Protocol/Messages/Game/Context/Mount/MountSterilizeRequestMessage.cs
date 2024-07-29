namespace Stigma.Protocol.Messages.Game.Context.Mount;

public sealed class MountSterilizeRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5962;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public MountSterilizeRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}