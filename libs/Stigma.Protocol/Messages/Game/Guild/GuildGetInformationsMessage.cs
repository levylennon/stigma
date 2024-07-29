namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildGetInformationsMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5550;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte InfoType { get; set; }

    public GuildGetInformationsMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(InfoType);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        InfoType = reader.ReadInt8();
    }
}