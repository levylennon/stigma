namespace Stigma.Protocol.Types.Game.Context;

public sealed class IdentifiedEntityDispositionInformations : EntityDispositionInformations
{
    public new const ushort ProtocolTypeId = 107;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int Id { get; set; }

    public IdentifiedEntityDispositionInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(Id);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        Id = reader.ReadInt32();
    }
}