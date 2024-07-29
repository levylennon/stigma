namespace Stigma.Protocol.Types.Game.Context.Roleplay.Job;

public sealed class JobExperience : DofusType
{
    public new const ushort ProtocolTypeId = 98;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public sbyte JobId { get; set; }

    public sbyte JobLevel { get; set; }

    public double JobXP { get; set; }

    public double JobXpLevelFloor { get; set; }

    public double JobXpNextLevelFloor { get; set; }

    public JobExperience()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(JobId);
        writer.WriteInt8(JobLevel);
        writer.WriteDouble(JobXP);
        writer.WriteDouble(JobXpLevelFloor);
        writer.WriteDouble(JobXpNextLevelFloor);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        JobId = reader.ReadInt8();
        JobLevel = reader.ReadInt8();
        JobXP = reader.ReadDouble();
        JobXpLevelFloor = reader.ReadDouble();
        JobXpNextLevelFloor = reader.ReadDouble();
    }
}