namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildLevelUpMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6062;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required byte NewLevel { get; set; }

    public GuildLevelUpMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUInt8(NewLevel);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        NewLevel = reader.ReadUInt8();
    }
}