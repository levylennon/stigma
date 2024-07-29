namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Quest;

public sealed class GuidedModeReturnRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6088;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public GuidedModeReturnRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}