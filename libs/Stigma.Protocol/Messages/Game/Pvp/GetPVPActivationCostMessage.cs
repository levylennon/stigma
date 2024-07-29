namespace Stigma.Protocol.Messages.Game.Pvp;

public sealed class GetPVPActivationCostMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 1811;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public GetPVPActivationCostMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}