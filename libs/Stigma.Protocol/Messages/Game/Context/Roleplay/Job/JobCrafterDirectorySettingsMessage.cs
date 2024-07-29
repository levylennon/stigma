using Stigma.Protocol.Types.Game.Context.Roleplay.Job;

namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Job;

public sealed class JobCrafterDirectorySettingsMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5652;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required IEnumerable<JobCrafterDirectorySettings> CraftersSettings { get; set; }

    public JobCrafterDirectorySettingsMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        var craftersSettingsBefore = writer.Position;
        var craftersSettingsCount = 0;
        writer.WriteInt16(0);
        foreach (var item in CraftersSettings)
        {
            item.Serialize(writer);
            craftersSettingsCount++;
        }

        var craftersSettingsAfter = writer.Position;
        writer.Seek(SeekOrigin.Begin, craftersSettingsBefore);
        writer.WriteInt16((short)craftersSettingsCount);
        writer.Seek(SeekOrigin.Begin, craftersSettingsAfter);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        var craftersSettingsCount = reader.ReadInt16();
        var craftersSettings = new JobCrafterDirectorySettings[craftersSettingsCount];
        for (var i = 0; i < craftersSettingsCount; i++)
        {
            var entry = new JobCrafterDirectorySettings();
            entry.Deserialize(reader);
            craftersSettings[i] = entry;
        }

        CraftersSettings = craftersSettings;
    }
}