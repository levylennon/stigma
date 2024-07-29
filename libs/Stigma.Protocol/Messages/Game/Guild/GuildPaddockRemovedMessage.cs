namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class GuildPaddockRemovedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5955;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short WorldX { get; set; }

    public required short WorldY { get; set; }

    public GuildPaddockRemovedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(WorldX);
        writer.WriteInt16(WorldY);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        WorldX = reader.ReadInt16();
        WorldY = reader.ReadInt16();
    }
}