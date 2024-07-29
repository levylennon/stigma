using Stigma.Protocol.Types.Game.Look;

namespace Stigma.Protocol.Types.Game.Guild.Tax;

public class TaxCollectorInformations : DofusType
{
    public new const ushort ProtocolTypeId = 167;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int UniqueId { get; set; }

    public short FirtNameId { get; set; }

    public short LastNameId { get; set; }

    public AdditionalTaxCollectorInformations AdditonalInformation { get; set; }

    public short WorldX { get; set; }

    public short WorldY { get; set; }

    public short SubAreaId { get; set; }

    public sbyte State { get; set; }

    public EntityLook Look { get; set; }

    public TaxCollectorInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(UniqueId);
        writer.WriteInt16(FirtNameId);
        writer.WriteInt16(LastNameId);
        AdditonalInformation.Serialize(writer);
        writer.WriteInt16(WorldX);
        writer.WriteInt16(WorldY);
        writer.WriteInt16(SubAreaId);
        writer.WriteInt8(State);
        Look.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        UniqueId = reader.ReadInt32();
        FirtNameId = reader.ReadInt16();
        LastNameId = reader.ReadInt16();
        AdditonalInformation = new AdditionalTaxCollectorInformations();
        AdditonalInformation.Deserialize(reader);
        WorldX = reader.ReadInt16();
        WorldY = reader.ReadInt16();
        SubAreaId = reader.ReadInt16();
        State = reader.ReadInt8();
        Look = new EntityLook();
        Look.Deserialize(reader);
    }
}