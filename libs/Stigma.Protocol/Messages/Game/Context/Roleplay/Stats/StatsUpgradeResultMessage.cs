namespace Stigma.Protocol.Messages.Game.Context.Roleplay.Stats;

public sealed class StatsUpgradeResultMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5609;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required short NbCharacBoost { get; set; }

    public StatsUpgradeResultMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt16(NbCharacBoost);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        NbCharacBoost = reader.ReadInt16();
    }
}