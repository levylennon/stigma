namespace Stigma.Protocol.Types.Game.Guild.Tax;

public sealed class AdditionalTaxCollectorInformations : DofusType
{
    public new const ushort ProtocolTypeId = 165;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public string CollectorCallerName { get; set; }

    public int Date { get; set; }

    public AdditionalTaxCollectorInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUtf(CollectorCallerName);
        writer.WriteInt32(Date);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        CollectorCallerName = reader.ReadUtf();
        Date = reader.ReadInt32();
    }
}