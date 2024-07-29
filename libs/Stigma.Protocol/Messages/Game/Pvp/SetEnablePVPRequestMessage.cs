namespace Stigma.Protocol.Messages.Game.Pvp;

public sealed class SetEnablePVPRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 1810;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required bool Enable { get; set; }

    public SetEnablePVPRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteBoolean(Enable);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Enable = reader.ReadBoolean();
    }
}