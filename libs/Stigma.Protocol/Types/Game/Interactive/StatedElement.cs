namespace Stigma.Protocol.Types.Game.Interactive;

public sealed class StatedElement : DofusType
{
    public new const ushort ProtocolTypeId = 108;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int ElementId { get; set; }

    public short ElementCellId { get; set; }

    public int ElementState { get; set; }

    public StatedElement()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(ElementId);
        writer.WriteInt16(ElementCellId);
        writer.WriteInt32(ElementState);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ElementId = reader.ReadInt32();
        ElementCellId = reader.ReadInt16();
        ElementState = reader.ReadInt32();
    }
}