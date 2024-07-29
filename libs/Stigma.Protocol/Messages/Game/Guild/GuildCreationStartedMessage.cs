namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildCreationStartedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5920;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public GuildCreationStartedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}