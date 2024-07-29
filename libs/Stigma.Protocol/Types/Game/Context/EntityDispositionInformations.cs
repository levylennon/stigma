namespace Stigma.Protocol.Types.Game.Context;

public class EntityDispositionInformations : DofusType
{
    public new const ushort ProtocolTypeId = 60;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short CellId { get; set; }

    public sbyte Direction { get; set; }

    public EntityDispositionInformations()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(CellId);
        writer.WriteInt8(Direction);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        CellId = reader.ReadInt16();
        Direction = reader.ReadInt8();
    }
}