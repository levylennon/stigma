using Stigma.Protocol.Types.Game.Context.Roleplay.Job;

namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Job;

public sealed class JobCrafterDirectoryDefineSettingsMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5649;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required JobCrafterDirectorySettings Settings { get; set; }

    public JobCrafterDirectoryDefineSettingsMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        Settings.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Settings = new JobCrafterDirectorySettings();
        Settings.Deserialize(reader);
    }
}