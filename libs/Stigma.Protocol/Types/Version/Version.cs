namespace Stigma.Protocol.Types.Version;

public sealed class Version : DofusType
{
    public new const ushort ProtocolTypeId = 11;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public sbyte Major { get; set; }

    public sbyte Minor { get; set; }

    public sbyte Revision { get; set; }

    public sbyte BuildType { get; set; }

    public Version()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(Major);
        writer.WriteInt8(Minor);
        writer.WriteInt8(Revision);
        writer.WriteInt8(BuildType);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Major = reader.ReadInt8();
        Minor = reader.ReadInt8();
        Revision = reader.ReadInt8();
        BuildType = reader.ReadInt8();
    }
}