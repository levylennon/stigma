namespace Stigma.Protocol.Types.Game.Context.Roleplay.Job;

public sealed class JobCrafterDirectorySettings : DofusType
{
    public new const ushort ProtocolTypeId = 97;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public sbyte JobId { get; set; }

    public sbyte MinSlot { get; set; }

    public sbyte UserDefinedParams { get; set; }

    public JobCrafterDirectorySettings()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(JobId);
        writer.WriteInt8(MinSlot);
        writer.WriteInt8(UserDefinedParams);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        JobId = reader.ReadInt8();
        MinSlot = reader.ReadInt8();
        UserDefinedParams = reader.ReadInt8();
    }
}