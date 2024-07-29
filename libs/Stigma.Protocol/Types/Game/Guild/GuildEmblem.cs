namespace Stigma.Protocol.Types.Game.Guild;

public sealed class GuildEmblem : DofusType
{
    public new const ushort ProtocolTypeId = 87;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public short SymbolShape { get; set; }

    public int SymbolColor { get; set; }

    public short BackgroundShape { get; set; }

    public int BackgroundColor { get; set; }

    public GuildEmblem()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(SymbolShape);
        writer.WriteInt32(SymbolColor);
        writer.WriteInt16(BackgroundShape);
        writer.WriteInt32(BackgroundColor);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        SymbolShape = reader.ReadInt16();
        SymbolColor = reader.ReadInt32();
        BackgroundShape = reader.ReadInt16();
        BackgroundColor = reader.ReadInt32();
    }
}