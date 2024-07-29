namespace Stigma.Protocol.Types.Game.Context.Roleplay.Job;

public sealed class JobCrafterDirectoryEntryPlayerInfo : DofusType
{
    public new const ushort ProtocolTypeId = 194;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public int PlayerId { get; set; }

    public string PlayerName { get; set; }

    public sbyte AlignmentSide { get; set; }

    public sbyte Breed { get; set; }

    public bool Sex { get; set; }

    public bool IsInWorkshop { get; set; }

    public short WorldX { get; set; }

    public short WorldY { get; set; }

    public int MapId { get; set; }

    public short SubareaId { get; set; }

    public JobCrafterDirectoryEntryPlayerInfo()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(PlayerId);
        writer.WriteUtf(PlayerName);
        writer.WriteInt8(AlignmentSide);
        writer.WriteInt8(Breed);
        writer.WriteBoolean(Sex);
        writer.WriteBoolean(IsInWorkshop);
        writer.WriteInt16(WorldX);
        writer.WriteInt16(WorldY);
        writer.WriteInt32(MapId);
        writer.WriteInt16(SubareaId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        PlayerId = reader.ReadInt32();
        PlayerName = reader.ReadUtf();
        AlignmentSide = reader.ReadInt8();
        Breed = reader.ReadInt8();
        Sex = reader.ReadBoolean();
        IsInWorkshop = reader.ReadBoolean();
        WorldX = reader.ReadInt16();
        WorldY = reader.ReadInt16();
        MapId = reader.ReadInt32();
        SubareaId = reader.ReadInt16();
    }
}