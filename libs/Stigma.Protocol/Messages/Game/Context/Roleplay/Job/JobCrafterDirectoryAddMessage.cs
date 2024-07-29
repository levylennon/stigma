using Stigma.Protocol.Types.Game.Context.Roleplay.Job;

namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Job;

public sealed class JobCrafterDirectoryAddMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5651;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required JobCrafterDirectoryListEntry ListEntry { get; set; }

    public JobCrafterDirectoryAddMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        ListEntry.Serialize(writer);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ListEntry = new JobCrafterDirectoryListEntry();
        ListEntry.Deserialize(reader);
    }
}