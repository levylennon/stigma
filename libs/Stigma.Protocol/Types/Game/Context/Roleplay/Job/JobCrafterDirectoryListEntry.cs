namespace Stigma.Protocol.Types.Game.Context.Roleplay.Job;

public sealed class JobCrafterDirectoryListEntry : DofusType
{
    public new const ushort ProtocolTypeId = 196;

    public override ushort ProtocolId =>
        ProtocolTypeId;

    public JobCrafterDirectoryEntryPlayerInfo PlayerInfo { get; set; }

    public JobCrafterDirectoryEntryJobInfo JobInfo { get; set; }

    public JobCrafterDirectoryListEntry()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        PlayerInfo.Serialize(writer);
        JobInfo.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        PlayerInfo = new JobCrafterDirectoryEntryPlayerInfo();
        PlayerInfo.Deserialize(reader);
        JobInfo = new JobCrafterDirectoryEntryJobInfo();
        JobInfo.Deserialize(reader);
    }
}