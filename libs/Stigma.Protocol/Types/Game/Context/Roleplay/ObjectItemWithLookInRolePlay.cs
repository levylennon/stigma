using Stigma.Protocol.Types.Game.Look;

namespace Stigma.Protocol.Types.Game.Context.Roleplay;

public class ObjectItemWithLookInRolePlay : ObjectItemInRolePlay
{
    public new const ushort ProtocolTypeId = 197;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public EntityLook EntityLookValue { get; set; }

    public ObjectItemWithLookInRolePlay()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        EntityLookValue.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        EntityLookValue = new EntityLook();
        EntityLookValue.Deserialize(reader);
    }
}