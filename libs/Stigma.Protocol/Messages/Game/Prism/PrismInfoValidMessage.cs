using Stigma.Protocol.Types.Game.Fight;

namespace Stigma.Protocol.Messages.Game.Prism;

public sealed class PrismInfoValidMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5858;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required ProtectedEntityWaitingForHelpInfo WaitingForHelpInfo { get; set; }

    public PrismInfoValidMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        WaitingForHelpInfo.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        WaitingForHelpInfo = new ProtectedEntityWaitingForHelpInfo();
        WaitingForHelpInfo.Deserialize(reader);
    }
}