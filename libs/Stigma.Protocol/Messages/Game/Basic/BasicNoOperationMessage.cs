namespace Stigma.Protocol.Messages.Game.Basic;

public sealed class BasicNoOperationMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 176;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public BasicNoOperationMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}