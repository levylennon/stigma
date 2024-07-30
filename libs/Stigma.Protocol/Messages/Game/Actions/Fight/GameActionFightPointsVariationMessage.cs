namespace Stigma.Protocol.Messages.Game.Actions.Fight;

public sealed class GameActionFightPointsVariationMessage : AbstractGameActionMessage
{
    public new const uint ProtocolMessageId = 1030;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int TargetId { get; set; }

    public required short Delta { get; set; }

    public GameActionFightPointsVariationMessage()
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