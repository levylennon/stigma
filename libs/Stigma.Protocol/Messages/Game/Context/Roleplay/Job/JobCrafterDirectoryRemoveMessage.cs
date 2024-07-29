namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Job;

public sealed class JobCrafterDirectoryRemoveMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5653;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte JobId { get; set; }

    public required int PlayerId { get; set; }

    public JobCrafterDirectoryRemoveMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(JobId);
        writer.WriteInt32(PlayerId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        JobId = reader.ReadInt8();
        PlayerId = reader.ReadInt32();
    }
}