namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildUIOpenedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5561;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Type { get; set; }

    public GuildUIOpenedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(Type);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Type = reader.ReadInt8();
    }
}