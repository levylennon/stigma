namespace Stigma.Protocol.Messages.Game.Character.Stats;

public sealed class LifePointsRegenEndMessage : UpdateLifePointsMessage
{
    public new const uint ProtocolMessageId = 5686;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int LifePointsGained { get; set; }

    public LifePointsRegenEndMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt32(LifePointsGained);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        base.Deserialize(reader);
        LifePointsGained = reader.ReadInt32();
    }
}