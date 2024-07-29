using Stigma.Protocol.Types.Game.Context.Roleplay.Job;

namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Job;

public sealed class JobExperienceMultiUpdateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5809;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<JobExperience> ExperiencesUpdate { get; set; }

    public JobExperienceMultiUpdateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var experiencesUpdateBefore = writer.Position;
        var experiencesUpdateCount = 0;
        writer.WriteInt16(0);
        foreach (var item in ExperiencesUpdate)
        {
            item.Serialize(writer);
            experiencesUpdateCount++;
        }

        var experiencesUpdateAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, experiencesUpdateBefore);
        writer.WriteInt16((short)experiencesUpdateCount);
        writer.Seek(SeekOrigin.Begin, experiencesUpdateAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var experiencesUpdateCount = reader.ReadInt16();
        var experiencesUpdate = new JobExperience[experiencesUpdateCount];
        for (var i = 0; i < experiencesUpdateCount; i++)
        {
            var entry = new JobExperience();
            entry.Deserialize(reader);
            experiencesUpdate[i] = entry;
        }

        ExperiencesUpdate = experiencesUpdate;
    }
}