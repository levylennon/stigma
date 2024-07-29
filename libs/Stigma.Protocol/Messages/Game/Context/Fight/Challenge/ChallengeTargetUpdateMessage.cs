namespace Stigma.Protocol.Messages.Game.Context.Fight.Challenge;

public sealed class ChallengeTargetUpdateMessage : DofusMessage
{
    public new const uint ProtocolMessageId = 6123;

    public override uint ProtocolId =>
        ProtocolMessageId;

    public required sbyte ChallengeId { get; set; }

    public required int TargetId { get; set; }

    public ChallengeTargetUpdateMessage()
    {
    }

    public override void Serialize(BigEndianWriter writer)
    {
        writer.WriteInt8(ChallengeId);
        writer.WriteInt32(TargetId);
    }

    public override void Deserialize(BigEndianReader reader)
    {
        ChallengeId = reader.ReadInt8();
        TargetId = reader.ReadInt32();
    }
}