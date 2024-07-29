namespace Stigma.Protocol.Types.Game.Prism;

public sealed class PrismConquestInformation : DofusType
{
    public new const ushort ProtocolTypeId = 152;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public bool IsEntered { get; set; }

    public bool IsInRoom { get; set; }

    public int SubId { get; set; }

    public sbyte Alignment { get; set; }

    public PrismConquestInformation()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, IsEntered);
        flag = BooleanByteWrapper.SetFlag(flag, 1, IsInRoom);
        writer.WriteUInt8(flag);
        writer.WriteInt32(SubId);
        writer.WriteInt8(Alignment);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var flag = reader.ReadUInt8();
        IsEntered = BooleanByteWrapper.GetFlag(flag, 0);
        IsInRoom = BooleanByteWrapper.GetFlag(flag, 1);
        SubId = reader.ReadInt32();
        Alignment = reader.ReadInt8();
    }
}