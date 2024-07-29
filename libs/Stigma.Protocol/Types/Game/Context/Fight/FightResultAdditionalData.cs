namespace Stigma.Protocol.Types.Game.Context.Fight;

public class FightResultAdditionalData : DofusType
{
    public new const ushort ProtocolTypeId = 191;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public FightResultAdditionalData()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}