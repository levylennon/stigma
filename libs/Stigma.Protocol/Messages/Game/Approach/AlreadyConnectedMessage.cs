namespace Stigma.Protocol.Messages.Game.Approach;

public sealed class AlreadyConnectedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 109;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public AlreadyConnectedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}