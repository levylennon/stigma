namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Objects;

public sealed class ObjectGroundRemovedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 3014;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short Cell { get; set; }

    public ObjectGroundRemovedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(Cell);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        Cell = reader.ReadInt16();
    }
}