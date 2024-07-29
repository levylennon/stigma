namespace Stigma.Protocol.Messages.Game.Context.Mount;

public sealed class PaddockSellRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5953;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Price { get; set; }

    public PaddockSellRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Price);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Price = reader.ReadInt32();
    }
}