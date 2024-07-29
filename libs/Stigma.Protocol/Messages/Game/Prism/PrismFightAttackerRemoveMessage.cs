namespace Stigma.Protocol.Messages.Game.Prism;

public sealed class PrismFightAttackerRemoveMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5897;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required double FightId { get; set; }

    public required int FighterToRemoveId { get; set; }

    public PrismFightAttackerRemoveMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteDouble(FightId);
        writer.WriteInt32(FighterToRemoveId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FightId = reader.ReadDouble();
        FighterToRemoveId = reader.ReadInt32();
    }
}