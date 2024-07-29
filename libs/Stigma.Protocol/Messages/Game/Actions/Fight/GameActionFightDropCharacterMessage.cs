namespace Stigma.Protocol.Messages.Game.Actions.Fight;

public sealed class GameActionFightDropCharacterMessage : AbstractGameActionMessage
{
    public new const uint ProtocolMessageId = 5826;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int TargetId { get; set; }

    public required short CellId { get; set; }

    public GameActionFightDropCharacterMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(TargetId);
        writer.WriteInt16(CellId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        TargetId = reader.ReadInt32();
        CellId = reader.ReadInt16();
    }
}