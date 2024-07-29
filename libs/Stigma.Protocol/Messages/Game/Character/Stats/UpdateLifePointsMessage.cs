namespace Stigma.Protocol.Messages.Game.Character.Stats;

public class UpdateLifePointsMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5658;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int LifePoints { get; set; }

    public required int MaxLifePoints { get; set; }

    public UpdateLifePointsMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(LifePoints);
        writer.WriteInt32(MaxLifePoints);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        LifePoints = reader.ReadInt32();
        MaxLifePoints = reader.ReadInt32();
    }
}