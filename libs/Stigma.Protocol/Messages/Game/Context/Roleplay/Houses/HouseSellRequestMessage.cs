namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Houses;

public class HouseSellRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5697;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int Amount { get; set; }

    public HouseSellRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Amount);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Amount = reader.ReadInt32();
    }
}