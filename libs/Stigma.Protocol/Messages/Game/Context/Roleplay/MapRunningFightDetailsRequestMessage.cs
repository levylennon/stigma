namespace Stigma.Protocol.Messages.Game.Context.Roleplay;

public sealed class MapRunningFightDetailsRequestMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5750;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int FightId { get; set; }

    public MapRunningFightDetailsRequestMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(FightId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        FightId = reader.ReadInt32();
    }
}