namespace Stigma.Protocol.Messages.Game.Context.Roleplay;

public sealed class TeleportOnSameMapMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6048;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int TargetId { get; set; }

    public required short CellId { get; set; }

    public TeleportOnSameMapMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(TargetId);
        writer.WriteInt16(CellId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        TargetId = reader.ReadInt32();
        CellId = reader.ReadInt16();
    }
}