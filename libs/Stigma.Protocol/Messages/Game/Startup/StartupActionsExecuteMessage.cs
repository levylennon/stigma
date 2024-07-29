namespace Stigma.Protocol.Messages.Game.Startup;

public sealed class StartupActionsExecuteMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 1302;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public StartupActionsExecuteMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}