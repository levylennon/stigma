namespace Stigma.Protocol.Messages.Game.Character.Stats;

public sealed class LifePointsRegenBeginMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5684;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required byte RegenRate { get; set; }

    public LifePointsRegenBeginMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteUInt8(RegenRate);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        RegenRate = reader.ReadUInt8();
    }
}