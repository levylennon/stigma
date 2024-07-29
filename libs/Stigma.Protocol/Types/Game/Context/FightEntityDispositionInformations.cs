namespace Stigma.Protocol.Types.Game.Context;

public sealed class FightEntityDispositionInformations : EntityDispositionInformations
{
    public new const ushort ProtocolTypeId = 217;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int CarryingCharacterId { get; set; }

    public FightEntityDispositionInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(CarryingCharacterId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        CarryingCharacterId = reader.ReadInt32();
    }
}