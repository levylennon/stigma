namespace Stigma.Protocol.Messages.Game.Approach;

public sealed class HelloGameMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 101;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public HelloGameMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}