namespace Stigma.Protocol.Types.Game.Paddock;

public sealed class MountInformationsForPaddock : DofusType
{
    public new const ushort ProtocolTypeId = 184;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int ModelId { get; set; }

    public string Name { get; set; }

    public string OwnerName { get; set; }

    public MountInformationsForPaddock()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(ModelId);
        writer.WriteUtf(Name);
        writer.WriteUtf(OwnerName);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ModelId = reader.ReadInt32();
        Name = reader.ReadUtf();
        OwnerName = reader.ReadUtf();
    }
}