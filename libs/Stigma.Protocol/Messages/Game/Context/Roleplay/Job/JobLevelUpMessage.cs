using Stigma.Protocol.Types.Game.Context.Roleplay.Job;

namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Job;

public sealed class JobLevelUpMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5656;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte NewLevel { get; set; }

    public required JobDescription JobsDescription { get; set; }

    public JobLevelUpMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(NewLevel);
        JobsDescription.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        NewLevel = reader.ReadInt8();
        JobsDescription = new JobDescription();
        JobsDescription.Deserialize(reader);
    }
}