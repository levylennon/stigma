namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Stats;

public sealed class StatsUpgradeRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5610;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte StatId { get; set; }

    public required short BoostPoint { get; set; }

    public StatsUpgradeRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(StatId);
        writer.WriteInt16(BoostPoint);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        StatId = reader.ReadInt8();
        BoostPoint = reader.ReadInt16();
    }
}