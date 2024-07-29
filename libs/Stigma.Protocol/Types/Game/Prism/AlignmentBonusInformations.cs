namespace Stigma.Protocol.Types.Game.Prism;

public sealed class AlignmentBonusInformations : DofusType
{
    public new const ushort ProtocolTypeId = 135;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int Pctbonus { get; set; }

    public double Grademult { get; set; }

    public AlignmentBonusInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(Pctbonus);
        writer.WriteDouble(Grademult);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Pctbonus = reader.ReadInt32();
        Grademult = reader.ReadDouble();
    }
}