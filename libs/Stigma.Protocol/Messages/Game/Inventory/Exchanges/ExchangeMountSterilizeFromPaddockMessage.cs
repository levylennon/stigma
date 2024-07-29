namespace Stigma.Protocol.Messages.Game.Inventory.Exchanges;

public sealed class ExchangeMountSterilizeFromPaddockMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6056;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required string Name { get; set; }

    public required short WorldX { get; set; }

    public required short WorldY { get; set; }

    public required string Sterilizator { get; set; }

    public ExchangeMountSterilizeFromPaddockMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUtf(Name);
        writer.WriteInt16(WorldX);
        writer.WriteInt16(WorldY);
        writer.WriteUtf(Sterilizator);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Name = reader.ReadUtf();
        WorldX = reader.ReadInt16();
        WorldY = reader.ReadInt16();
        Sterilizator = reader.ReadUtf();
    }
}