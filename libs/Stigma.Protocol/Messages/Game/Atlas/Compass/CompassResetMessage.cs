namespace Stigma.Protocol.Messages.Game.Atlas.Compass;

public sealed class CompassResetMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5584;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public CompassResetMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}