namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Houses.Guild;

public sealed class HouseGuildRightsViewMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5700;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public HouseGuildRightsViewMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}