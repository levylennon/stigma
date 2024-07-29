namespace Stigma.Protocol.Messages.Game.Friend;

public sealed class IgnoredGetListMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5676;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public IgnoredGetListMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}