namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Emote;

public sealed class EmotePlayErrorMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5688;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public EmotePlayErrorMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}