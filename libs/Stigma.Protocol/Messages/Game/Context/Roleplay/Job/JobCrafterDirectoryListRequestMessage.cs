namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Job;

public sealed class JobCrafterDirectoryListRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6047;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte JobId { get; set; }

    public JobCrafterDirectoryListRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(JobId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        JobId = reader.ReadInt8();
    }
}