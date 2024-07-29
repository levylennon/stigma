using Stigma.Protocol.Messages.Game.Dialog;

namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeLeaveMessage : LeaveDialogMessage
{
    public new const uint ProtocolMessageId = 5628;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Success { get; set; }

    public ExchangeLeaveMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteBoolean(Success);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Success = reader.ReadBoolean();
    }
}