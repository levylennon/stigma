namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Quest;

public sealed class GuidedModeQuitRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6092;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public GuidedModeQuitRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}