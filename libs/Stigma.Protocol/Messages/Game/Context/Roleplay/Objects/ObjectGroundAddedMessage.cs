namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Objects;

public sealed class ObjectGroundAddedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 3017;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short CellId { get; set; }

    public required short ObjectGID { get; set; }

    public ObjectGroundAddedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(CellId);
        writer.WriteInt16(ObjectGID);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        CellId = reader.ReadInt16();
        ObjectGID = reader.ReadInt16();
    }
}