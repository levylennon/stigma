namespace Stigma.Protocol.Messages.Game.Context.Fight.Challenge;

public sealed class ChallengeResultMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6019;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte ChallengeId { get; set; }

    public required bool Success { get; set; }

    public ChallengeResultMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(ChallengeId);
        writer.WriteBoolean(Success);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ChallengeId = reader.ReadInt8();
        Success = reader.ReadBoolean();
    }
}