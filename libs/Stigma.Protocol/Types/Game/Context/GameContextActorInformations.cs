using Stigma.Protocol.Types.Game.Look;

namespace Stigma.Protocol.Types.Game.Context;

public class GameContextActorInformations : DofusType
{
    public new const ushort ProtocolTypeId = 150;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int ContextualId { get; set; }

    public EntityLook Look { get; set; }

    public EntityDispositionInformations Disposition { get; set; }

    public GameContextActorInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(ContextualId);
        Look.Serialize(writer);
        writer.WriteUInt16(Disposition.ProtocolId);
        Disposition.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ContextualId = reader.ReadInt32();
        Look = new EntityLook();
        Look.Deserialize(reader);
        Disposition = DofusTypeFactory.CreateInstance<EntityDispositionInformations>(reader.ReadUInt16());
        Disposition.Deserialize(reader);
    }
}