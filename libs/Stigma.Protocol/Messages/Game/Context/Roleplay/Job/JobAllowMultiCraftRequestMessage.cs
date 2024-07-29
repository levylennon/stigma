namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Job;

public class JobAllowMultiCraftRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5748;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Enabled { get; set; }

    public JobAllowMultiCraftRequestMessage()
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