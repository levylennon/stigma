namespace Stigma.Protocol.Types.Game.Prism;

public sealed class PrismSubAreaInformation : DofusType
{
    public new const ushort ProtocolTypeId = 142;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public bool IsInFight { get; set; }

    public bool IsFightable { get; set; }

    public int SubId { get; set; }

    public sbyte Alignment { get; set; }

    public int MapId { get; set; }

    public PrismSubAreaInformation()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, IsInFight);
        flag = BooleanByteWrapper.SetFlag(flag, 1, IsFightable);
        writer.WriteUInt8(flag);
        writer.WriteInt32(SubId);
        writer.WriteInt8(Alignment);
        writer.WriteInt32(MapId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var flag = reader.ReadUInt8();
        IsInFight = BooleanByteWrapper.GetFlag(flag, 0);
        IsFightable = BooleanByteWrapper.GetFlag(flag, 1);
        SubId = reader.ReadInt32();
        Alignment = reader.ReadInt8();
        MapId = reader.ReadInt32();
    }
}