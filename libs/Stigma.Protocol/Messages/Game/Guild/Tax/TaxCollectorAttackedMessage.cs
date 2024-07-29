namespace Stigma.Protocol.Messages.Game.Guild.Tax;

public sealed class TaxCollectorAttackedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5918;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short FirstNameId { get; set; }

    public required short LastNameId { get; set; }

    public required short WorldX { get; set; }

    public required short WorldY { get; set; }

    public required int MapId { get; set; }

    public TaxCollectorAttackedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(FirstNameId);
        writer.WriteInt16(LastNameId);
        writer.WriteInt16(WorldX);
        writer.WriteInt16(WorldY);
        writer.WriteInt32(MapId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FirstNameId = reader.ReadInt16();
        LastNameId = reader.ReadInt16();
        WorldX = reader.ReadInt16();
        WorldY = reader.ReadInt16();
        MapId = reader.ReadInt32();
    }
}