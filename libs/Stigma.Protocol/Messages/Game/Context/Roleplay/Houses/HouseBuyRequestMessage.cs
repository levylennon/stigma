namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Houses;

public sealed class HouseBuyRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5738;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int ProposedPrice { get; set; }

    public HouseBuyRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(ProposedPrice);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ProposedPrice = reader.ReadInt32();
    }
}