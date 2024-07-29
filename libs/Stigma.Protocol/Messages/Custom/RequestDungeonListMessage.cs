namespace Stigma.Protocol.Messages.Custom;

public sealed class RequestDungeonListMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6400;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public RequestDungeonListMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}