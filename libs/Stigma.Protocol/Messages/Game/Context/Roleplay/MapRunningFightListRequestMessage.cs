namespace Stigma.Protocol.Messages.Game.Context.Roleplay;

public sealed class MapRunningFightListRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5742;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public MapRunningFightListRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}