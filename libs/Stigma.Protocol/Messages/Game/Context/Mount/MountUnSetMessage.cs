namespace Stigma.Protocol.Messages.Game.Context.Mount;

public sealed class MountUnSetMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5982;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public MountUnSetMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}