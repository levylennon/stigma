namespace Stigma.Protocol.Messages.Game.Guild;

public sealed class ChallengeFightJoinRefusedMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 5908;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required int PlayerId { get; set; }

    public required sbyte Reason { get; set; }

    public ChallengeFightJoinRefusedMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt32(PlayerId);
        writer.WriteInt8(Reason);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        PlayerId = reader.ReadInt32();
        Reason = reader.ReadInt8();
    }
}