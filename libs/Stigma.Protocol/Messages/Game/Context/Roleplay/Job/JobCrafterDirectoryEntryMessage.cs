using Stigma.Protocol.Types.Game.Context.Roleplay.Job;
using Stigma.Protocol.Types.Game.Look;

namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Job;

public sealed class JobCrafterDirectoryEntryMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6044;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required JobCrafterDirectoryEntryPlayerInfo PlayerInfo { get; set; }

    public required IEnumerable<JobCrafterDirectoryEntryJobInfo> JobInfoList { get; set; }

    public required EntityLook PlayerLook { get; set; }

    public JobCrafterDirectoryEntryMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        PlayerInfo.Serialize(writer);
        var jobInfoListBefore = writer.Position;
        var jobInfoListCount = 0;
        writer.WriteInt16(0);
        foreach (var item in JobInfoList)
        {
            item.Serialize(writer);
            jobInfoListCount++;
        }

        var jobInfoListAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, jobInfoListBefore);
        writer.WriteInt16((short)jobInfoListCount);
        writer.Seek(SeekOrigin.Begin, jobInfoListAfter);
        PlayerLook.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        PlayerInfo = new JobCrafterDirectoryEntryPlayerInfo();
        PlayerInfo.Deserialize(reader);
        var jobInfoListCount = reader.ReadInt16();
        var jobInfoList = new JobCrafterDirectoryEntryJobInfo[jobInfoListCount];
        for (var i = 0; i < jobInfoListCount; i++)
        {
            var entry = new JobCrafterDirectoryEntryJobInfo();
            entry.Deserialize(reader);
            jobInfoList[i] = entry;
        }

        JobInfoList = jobInfoList;
        PlayerLook = new EntityLook();
        PlayerLook.Deserialize(reader);
    }
}