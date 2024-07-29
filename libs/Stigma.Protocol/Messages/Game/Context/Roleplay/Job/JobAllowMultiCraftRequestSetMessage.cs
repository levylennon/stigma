namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Job;

public sealed class JobAllowMultiCraftRequestSetMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5749;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Enabled { get; set; }

    public JobAllowMultiCraftRequestSetMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(Enabled);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Enabled = reader.ReadBoolean();
    }
}