namespace Stigma.Protocol.Types.Game.Guild.Tax;

public sealed class TaxCollectorName : DofusType
{
    public new const ushort ProtocolTypeId = 187;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short FirstNameId { get; set; }

    public short LastNameId { get; set; }

    public TaxCollectorName()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(FirstNameId);
        writer.WriteInt16(LastNameId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FirstNameId = reader.ReadInt16();
        LastNameId = reader.ReadInt16();
    }
}