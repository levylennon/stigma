namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildLeftMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5562;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public GuildLeftMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}