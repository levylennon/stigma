namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Houses;

public sealed class HouseSellFromInsideRequestMessage : HouseSellRequestMessage
{
    public new const uint ProtocolMessageId = 5884;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public HouseSellFromInsideRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
    }
}