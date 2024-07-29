namespace Stigma.Protocol.Messages.Game.Actions.Fight;

public sealed class GameActionFightUnmarkCellsMessage : AbstractGameActionMessage
{
    public new const uint ProtocolMessageId = 5570;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short MarkId { get; set; }

    public GameActionFightUnmarkCellsMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt16(MarkId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        MarkId = reader.ReadInt16();
    }
}