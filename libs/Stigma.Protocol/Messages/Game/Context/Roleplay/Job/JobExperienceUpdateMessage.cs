using Stigma.Protocol.Types.Game.Context.Roleplay.Job;

namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Job;

public sealed class JobExperienceUpdateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5654;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required JobExperience ExperiencesUpdate { get; set; }

    public JobExperienceUpdateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        ExperiencesUpdate.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ExperiencesUpdate = new JobExperience();
        ExperiencesUpdate.Deserialize(reader);
    }
}