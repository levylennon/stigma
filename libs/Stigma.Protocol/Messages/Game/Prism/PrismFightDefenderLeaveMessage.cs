namespace Stigma.Protocol.Messages.Game.Prism;

public sealed class PrismFightDefenderLeaveMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5892;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required double FightId { get; set; }

    public required int FighterToRemoveId { get; set; }

    public required int Successor { get; set; }

    public PrismFightDefenderLeaveMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteDouble(FightId);
        writer.WriteInt32(FighterToRemoveId);
        writer.WriteInt32(Successor);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FightId = reader.ReadDouble();
        FighterToRemoveId = reader.ReadInt32();
        Successor = reader.ReadInt32();
    }
}