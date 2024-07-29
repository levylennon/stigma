using Stigma.Protocol.Types.Game.Interactive;

namespace Stigma.Protocol.Messages.Game.Interactive;

public sealed class StatedElementUpdatedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5709;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required StatedElement StatedElementValue { get; set; }

    public StatedElementUpdatedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        StatedElementValue.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        StatedElementValue = new StatedElement();
        StatedElementValue.Deserialize(reader);
    }
}