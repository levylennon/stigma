namespace Stigma.Protocol.Messages.Game.Basic;

public sealed class BasicWhoAmIRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5664;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public BasicWhoAmIRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}