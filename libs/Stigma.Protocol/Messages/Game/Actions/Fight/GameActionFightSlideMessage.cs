namespace Stigma.Protocol.Messages.Game.Actions.Fight;

public sealed class GameActionFightSlideMessage : AbstractGameActionMessage
{
    public new const uint ProtocolMessageId = 5525;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int TargetId { get; set; }

    public required short StartCellId { get; set; }

    public required short EndCellId { get; set; }

    public GameActionFightSlideMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(TargetId);
        writer.WriteInt16(StartCellId);
        writer.WriteInt16(EndCellId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        TargetId = reader.ReadInt32();
        StartCellId = reader.ReadInt16();
        EndCellId = reader.ReadInt16();
    }
}