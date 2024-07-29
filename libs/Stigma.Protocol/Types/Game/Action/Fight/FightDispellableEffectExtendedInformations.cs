using Stigma.Protocol.Types.Game.Actions.Fight;

namespace Stigma.Protocol.Types.Game.Action.Fight;

public sealed class FightDispellableEffectExtendedInformations : DofusType
{
    public new const ushort ProtocolTypeId = 208;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short ActionId { get; set; }

    public int SourceId { get; set; }

    public AbstractFightDispellableEffect Effect { get; set; }

    public FightDispellableEffectExtendedInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(ActionId);
        writer.WriteInt32(SourceId);
        writer.WriteUInt16(Effect.ProtocolId);
        Effect.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ActionId = reader.ReadInt16();
        SourceId = reader.ReadInt32();
        Effect = DofusTypeFactory.CreateInstance<AbstractFightDispellableEffect>(reader.ReadUInt16());
        Effect.Deserialize(reader);
    }
}