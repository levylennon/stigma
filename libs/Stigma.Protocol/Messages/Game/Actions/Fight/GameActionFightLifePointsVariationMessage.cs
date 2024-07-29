namespace Stigma.Protocol.Messages.Game.Actions.Fight;

public sealed class GameActionFightLifePointsVariationMessage : AbstractGameActionMessage
{
    public new const uint ProtocolMessageId = 5598;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int TargetId { get; set; }

    public required short Delta { get; set; }

    public GameActionFightLifePointsVariationMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(TargetId);
        writer.WriteInt16(Delta);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        TargetId = reader.ReadInt32();
        Delta = reader.ReadInt16();
    }
}