namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeMountFreeFromPaddockMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6055;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string Name { get; set; }

    public required short WorldX { get; set; }

    public required short WorldY { get; set; }

    public required string Liberator { get; set; }

    public ExchangeMountFreeFromPaddockMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUtf(Name);
        writer.WriteInt16(WorldX);
        writer.WriteInt16(WorldY);
        writer.WriteUtf(Liberator);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Name = reader.ReadUtf();
        WorldX = reader.ReadInt16();
        WorldY = reader.ReadInt16();
        Liberator = reader.ReadUtf();
    }
}