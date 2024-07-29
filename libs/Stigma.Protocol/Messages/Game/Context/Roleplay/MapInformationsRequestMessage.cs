namespace Stigma.Protocol.Messages.Game.Context.Roleplay;

public sealed class MapInformationsRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 225;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public MapInformationsRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}