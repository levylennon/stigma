namespace Stigma.Protocol.Messages.Game.Atlas.Compass;

public class CompassUpdateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5591;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte Type { get; set; }

    public required short WorldX { get; set; }

    public required short WorldY { get; set; }

    public CompassUpdateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(Type);
        writer.WriteInt16(WorldX);
        writer.WriteInt16(WorldY);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Type = reader.ReadInt8();
        WorldX = reader.ReadInt16();
        WorldY = reader.ReadInt16();
    }
}