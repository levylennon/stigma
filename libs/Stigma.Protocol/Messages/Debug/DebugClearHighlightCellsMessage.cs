namespace Stigma.Protocol.Messages.Debug;

public sealed class DebugClearHighlightCellsMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 2002;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public DebugClearHighlightCellsMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}