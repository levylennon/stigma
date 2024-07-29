namespace Stigma.Protocol.Types.Game.Guild.Tax;

public sealed class TaxCollectorBasicInformations : DofusType
{
    public new const ushort ProtocolTypeId = 96;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short FirstNameId { get; set; }

    public short LastNameId { get; set; }

    public int MapId { get; set; }

    public TaxCollectorBasicInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(FirstNameId);
        writer.WriteInt16(LastNameId);
        writer.WriteInt32(MapId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FirstNameId = reader.ReadInt16();
        LastNameId = reader.ReadInt16();
        MapId = reader.ReadInt32();
    }
}