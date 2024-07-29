namespace Stigma.Protocol.Types.Game.Data.Items;

public class Item : DofusType
{
    public new const ushort ProtocolTypeId = 7;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public Item()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
    }

    public override void Deserialize(BigEndianReader reader)
    {
    }
}