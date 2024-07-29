namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeMountTakenFromPaddockMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5994;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string Name { get; set; }

    public required short WorldX { get; set; }

    public required short WorldY { get; set; }

    public required string Ownername { get; set; }

    public ExchangeMountTakenFromPaddockMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUtf(Name);
        writer.WriteInt16(WorldX);
        writer.WriteInt16(WorldY);
        writer.WriteUtf(Ownername);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Name = reader.ReadUtf();
        WorldX = reader.ReadInt16();
        WorldY = reader.ReadInt16();
        Ownername = reader.ReadUtf();
    }
}