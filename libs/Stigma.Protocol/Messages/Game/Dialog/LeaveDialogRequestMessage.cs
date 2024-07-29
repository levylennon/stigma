namespace Stigma.Protocol.Messages.Game.Dialog;

public sealed class LeaveDialogRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5501;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public LeaveDialogRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}