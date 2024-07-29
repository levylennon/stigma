namespace Stigma.Protocol.Messages.Game.Actions;

public class AbstractGameActionMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 1000;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short ActionId { get; set; }

    public required int SourceId { get; set; }

    public AbstractGameActionMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(ActionId);
        writer.WriteInt32(SourceId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ActionId = reader.ReadInt16();
        SourceId = reader.ReadInt32();
    }
}