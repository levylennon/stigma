namespace Stigma.Protocol.Messages.Game.Prism;

public sealed class PrismFightDefendersSwapMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5902;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required double FightId { get; set; }

    public required int FighterId1 { get; set; }

    public required int FighterId2 { get; set; }

    public PrismFightDefendersSwapMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteDouble(FightId);
        writer.WriteInt32(FighterId1);
        writer.WriteInt32(FighterId2);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FightId = reader.ReadDouble();
        FighterId1 = reader.ReadInt32();
        FighterId2 = reader.ReadInt32();
    }
}