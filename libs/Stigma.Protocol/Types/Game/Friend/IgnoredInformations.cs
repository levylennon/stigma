namespace Stigma.Protocol.Types.Game.Friend;

public class IgnoredInformations : DofusType
{
    public new const ushort ProtocolTypeId = 106;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public string Name { get; set; }

    public IgnoredInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUtf(Name);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Name = reader.ReadUtf();
    }
}