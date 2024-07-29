namespace Stigma.Protocol.Messages.Game.Dialog;

public sealed class PauseDialogMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6012;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public PauseDialogMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}