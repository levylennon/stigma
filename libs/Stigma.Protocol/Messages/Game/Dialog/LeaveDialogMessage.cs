namespace Stigma.Protocol.Messages.Game.Dialog;

public class LeaveDialogMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5502;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public LeaveDialogMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}