using Stigma.Protocol.Types.Game.Look;

namespace Stigma.Protocol.Types.Game.Character;

public class CharacterMinimalPlusLookInformations : CharacterMinimalInformations
{
    public new const ushort ProtocolTypeId = 163;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public EntityLook EntityLookValue { get; set; }

    public CharacterMinimalPlusLookInformations()
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