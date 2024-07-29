using Stigma.Protocol.Types.Game.Context.Roleplay;
using Stigma.Protocol.Types.Game.Mount;

namespace Stigma.Protocol.Types.Game.Paddock;

public sealed class PaddockItem : ObjectItemInRolePlay
{
    public new const ushort ProtocolTypeId = 185;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public ItemDurability Durability { get; set; }

    public PaddockItem()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        Durability.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Durability = new ItemDurability();
        Durability.Deserialize(reader);
    }
}