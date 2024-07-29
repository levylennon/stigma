namespace Stigma.Protocol.Messages.Game.Context.Roleplay.House;

public sealed class HouseExitedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5861;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public HouseExitedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}