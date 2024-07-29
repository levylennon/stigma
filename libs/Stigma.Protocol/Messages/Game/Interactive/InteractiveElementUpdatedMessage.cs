using Stigma.Protocol.Types.Game.Interactive;

namespace Stigma.Protocol.Messages.Game.Interactive;

public sealed class InteractiveElementUpdatedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5708;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required InteractiveElement InteractiveElementValue { get; set; }

    public InteractiveElementUpdatedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        InteractiveElementValue.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        InteractiveElementValue = new InteractiveElement();
        InteractiveElementValue.Deserialize(reader);
    }
}