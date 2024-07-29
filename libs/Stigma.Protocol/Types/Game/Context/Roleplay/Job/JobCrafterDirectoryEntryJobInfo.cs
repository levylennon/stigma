namespace Stigma.Protocol.Types.Game.Context.Roleplay.Job;

public sealed class JobCrafterDirectoryEntryJobInfo : DofusType
{
    public new const ushort ProtocolTypeId = 195;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public sbyte JobId { get; set; }

    public sbyte JobLevel { get; set; }

    public sbyte UserDefinedParams { get; set; }

    public sbyte MinSlots { get; set; }

    public JobCrafterDirectoryEntryJobInfo()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(JobId);
        writer.WriteInt8(JobLevel);
        writer.WriteInt8(UserDefinedParams);
        writer.WriteInt8(MinSlots);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        JobId = reader.ReadInt8();
        JobLevel = reader.ReadInt8();
        UserDefinedParams = reader.ReadInt8();
        MinSlots = reader.ReadInt8();
    }
}