namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Job;

public sealed class JobCrafterDirectoryEntryRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6043;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int PlayerId { get; set; }

    public JobCrafterDirectoryEntryRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(PlayerId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        PlayerId = reader.ReadInt32();
    }
}