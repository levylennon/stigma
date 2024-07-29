namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Job;

public sealed class JobListedUpdateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6016;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool AddedOrDeleted { get; set; }

    public required sbyte JobId { get; set; }

    public JobListedUpdateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(AddedOrDeleted);
        writer.WriteInt8(JobId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        AddedOrDeleted = reader.ReadBoolean();
        JobId = reader.ReadInt8();
    }
}