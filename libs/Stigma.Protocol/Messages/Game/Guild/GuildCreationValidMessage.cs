using Stigma.Protocol.Types.Game.Guild;

namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildCreationValidMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5546;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string GuildName { get; set; }

    public required GuildEmblem GuildEmblemValue { get; set; }

    public GuildCreationValidMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUtf(GuildName);
        GuildEmblemValue.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        GuildName = reader.ReadUtf();
        GuildEmblemValue = new GuildEmblem();
        GuildEmblemValue.Deserialize(reader);
    }
}