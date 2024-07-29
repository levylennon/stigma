namespace Stigma.Protocol.Messages.Game.Interactive.Zaap;

public sealed class TeleportRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5961;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte TeleporterType { get; set; }

    public required int MapId { get; set; }

    public TeleportRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(TeleporterType);
        writer.WriteInt32(MapId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        TeleporterType = reader.ReadInt8();
        MapId = reader.ReadInt32();
    }
}