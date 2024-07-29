namespace Stigma.Protocol.Types.Game.Paddock;

public class PaddockInformations : DofusType
{
    public new const ushort ProtocolTypeId = 132;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short MaxOutdoorMount { get; set; }

    public short MaxItems { get; set; }

    public PaddockInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(MaxOutdoorMount);
        writer.WriteInt16(MaxItems);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        MaxOutdoorMount = reader.ReadInt16();
        MaxItems = reader.ReadInt16();
    }
}