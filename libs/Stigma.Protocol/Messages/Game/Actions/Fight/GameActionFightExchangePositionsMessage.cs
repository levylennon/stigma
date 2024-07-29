namespace Stigma.Protocol.Messages.Game.Actions.Fight;

public sealed class GameActionFightExchangePositionsMessage : AbstractGameActionMessage
{
    public new const uint ProtocolMessageId = 5527;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int TargetId { get; set; }

    public required short CasterCellId { get; set; }

    public required short TargetCellId { get; set; }

    public GameActionFightExchangePositionsMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(TargetId);
        writer.WriteInt16(CasterCellId);
        writer.WriteInt16(TargetCellId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        TargetId = reader.ReadInt32();
        CasterCellId = reader.ReadInt16();
        TargetCellId = reader.ReadInt16();
    }
}