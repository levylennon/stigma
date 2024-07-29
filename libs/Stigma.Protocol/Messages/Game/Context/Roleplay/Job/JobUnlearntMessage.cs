namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Job;

public sealed class JobUnlearntMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5657;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte JobId { get; set; }

    public JobUnlearntMessage()
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