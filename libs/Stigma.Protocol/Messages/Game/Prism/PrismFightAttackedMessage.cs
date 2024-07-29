namespace Stigma.Protocol.Messages.Game.Prism;

public sealed class PrismFightAttackedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5894;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short WorldX { get; set; }

    public required short WorldY { get; set; }

    public required int MapId { get; set; }

    public required short SubareaId { get; set; }

    public PrismFightAttackedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(WorldX);
        writer.WriteInt16(WorldY);
        writer.WriteInt32(MapId);
        writer.WriteInt16(SubareaId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        WorldX = reader.ReadInt16();
        WorldY = reader.ReadInt16();
        MapId = reader.ReadInt32();
        SubareaId = reader.ReadInt16();
    }
}